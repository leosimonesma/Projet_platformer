using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mouvements : MonoBehaviour
{
    //-------------------- Initialisation des variables --------------
    [SerializeField] float mouvement_speed = 40f;
    [SerializeField] float horizontalMove = 0f;
    float vitesseInit;
    [SerializeField] float jump_speed = 10f;
    [SerializeField] float dash_speed = 2f;
    [SerializeField] float dash_duration = 0.1f;
    [SerializeField] float couldown = 3f;
    [SerializeField] Animator Animator_player;
    [SerializeField] SpriteRenderer sprite_renderer;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] bool dashUp = true;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool CanMove = true;
    [SerializeField] bool PlayerControl = true;
    [SerializeField] int nbSaut = 1;
    [SerializeField] float groundCheckRadius;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask CollisionsLayers;
    public DialogueController IsAbleToMove;
    [SerializeField] float HorizontalMove = 0f;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = true;
    [Range(0, .3f)][SerializeField] private float MovementSmoothing = .05f;
    public GameObject Player;



    void Start()
    {

        vitesseInit = mouvement_speed;

    }


  
    void Update()
    {



         //  -------------------------- Appel Fonction d'actions --------------------------
         actions();

        // ----------------------------- Appel Fonction de Mouvement --------------------------------
        horizontalMove = Input.GetAxisRaw("Horizontal") * mouvement_speed;

        if (PlayerControl)
        {
            mouvement(horizontalMove * Time.fixedDeltaTime);
        }
    }
    void FixedUpdate()
    {


        // --------------------------------- IsGrounded -----------------------------------


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, CollisionsLayers);

        if (isGrounded)
        {
            Animator_player.SetBool("Booljump", false);
            isGrounded = true;
           
        }
        else
        {
            Animator_player.SetBool("Booljump", true);
            isGrounded = false;
            
        }





    }
    // ----------------------------- player stop animation -------------------------------- 
    public void stopMouvement()
    {
        horizontalMove = 0f;    
        rigidbody.velocity = Vector3.zero;
        PlayerControl = false;
        Animator_player.SetBool("BoolRun", false);
        Debug.Log("frezze");
    }
    public void playMouvement()
    {
        PlayerControl = true;

    }
 

    //---------------------------------------  fonction "mouvement"  -----------------------------------
   public void mouvement(float move)
    {
        if (horizontalMove > 0 && m_FacingRight)
        {
            Animator_player.SetBool("BoolRun", true);
            sprite_renderer.flipX = false;
        }
        else if (horizontalMove < 0 && !m_FacingRight)
        {
            Animator_player.SetBool("BoolRun", true);
            //sprite_renderer.flipX = true;
        }
        else if (horizontalMove ==0)
        {
            Animator_player.SetBool("BoolRun", false);

        }

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, rigidbody.velocity.y);
        // And then smoothing it out and applying it to the character
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

       
        // ---------------------- Slide --------------------------------
        if (Input.GetKeyDown(KeyCode.Keypad2))
            {

                Animator_player.SetBool("BoolSlide", true);

            }
            else
            {

                Animator_player.SetBool("BoolSlide", false);

            };
        
            // ------------------------- Jump --------------------------

            if (Input.GetKeyDown(KeyCode.UpArrow) && nbSaut > 0)
            {
                rigidbody.velocity = Vector2.up * jump_speed;
                nbSaut--;
            }

            if (isGrounded)
            {
                nbSaut = 1;
            }
      //  }



        // --------------------------- Coroutine du Dash --------------------------------

        IEnumerator Fonction_Dash()
        {
            //CanMove = false;
            dashUp = false;
            //multiplication de la vitesse
            mouvement_speed = mouvement_speed * dash_speed;


            // pause/durée
            yield return new WaitForSeconds(dash_duration);


            //Retablisement de la vitesse enregistréeé
            mouvement_speed = vitesseInit;

            //couldown
            yield return new WaitForSeconds(couldown);
            dashUp = true;
           







        }
        // --------------------------------- Dash ----------------------------------

        if (Input.GetKeyDown(KeyCode.Keypad3) && dashUp)
        {

            StartCoroutine(Fonction_Dash());

            Animator_player.SetBool("BoolDash", true);

        }
        else if (Input.GetKeyUp(KeyCode.Keypad3))
        {

            Animator_player.SetBool("BoolDash", false);

        };
    }

    // ------------------------- Flipping the player -------------------------------
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    // -------------------------------------- Initialisation de la fonction "actions" --------------------------------
    void actions()
    {
        // ---------------------------- Attaque ------------------------------
        void go_attack()
        {
            Animator_player.SetBool("BoolAttack", true);
            mouvement_speed = 0;
        }


        // Coroutine d'immobilisation durant une attaque 
        IEnumerator Fonction_Attack()
        {

            mouvement_speed = 0;
            yield return new WaitForSeconds(0.5f);
            mouvement_speed = vitesseInit;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {

            go_attack();
            StartCoroutine(Fonction_Attack());

        }
        else
        {

            Animator_player.SetBool("BoolAttack", false);

        };

    }
}
