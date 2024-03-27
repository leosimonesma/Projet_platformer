using System.Collections;
using UnityEngine;

public class Player_Mouvements : MonoBehaviour
{
    //-------------------- Initialisation des variables --------------


    // ----------------------- Mouvement --------------------
    public float mouvement_speed = 40f;
    public float mouvement_grab = 10f;
    public float horizontalMove = 0f;
    float vitesseInit;
    [SerializeField] bool CanMove = true;
    public bool PlayerControl = true;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = true;
    [Range(0, .3f)][SerializeField] private float MovementSmoothing = .05f;
    public pushetpull isPushing;


    // -------------------- Jump -------------------
    [SerializeField] float jump_speed = 10f;
    [SerializeField] bool isGrounded = false;
    [SerializeField] int nbSaut = 1;
    [SerializeField] float groundCheckRadius;
    [SerializeField] Transform groundCheck;
    [SerializeField] float coyoteTime = 0.5f;
    private float coyoteTimeCount;
    [SerializeField] LayerMask CollisionsLayers;
    [SerializeField] GameObject isGroundedCricle;
    [SerializeField] bool SecondJump = false;


    // ---------------- Dash ------------------------
    [SerializeField] float dash_speed = 2f;
    [SerializeField] float dash_duration = 0.1f;
    [SerializeField] float couldown = 3f;
    [SerializeField] bool dashUp = true;

    // ------------- Animations ----------------------------
    [SerializeField] Animator Animator_player;
    [SerializeField] SpriteRenderer sprite_renderer;
    [SerializeField] Rigidbody2D rigidbody;


  // ------------------ Actions -------------------------
    [SerializeField] bool CanAttack = true;




    void Start()
    {

        vitesseInit = mouvement_speed;

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

    // ----------------------------- player freez -------------------------------- 
    public void stopMouvement()
    {
        horizontalMove = 0f;    
        rigidbody.velocity = Vector3.zero;
        PlayerControl = false;
        Animator_player.SetBool("BoolRun", false);
        
    }
    //-------------------------------- player play defreez -------------------------------
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
           
        }
        else if (horizontalMove == 0)
        {
            Animator_player.SetBool("BoolRun", false);

        }

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, rigidbody.velocity.y);
        // And then smoothing it out and applying it to the character
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);

        // If the input is moving the player right and the player is facing left
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right
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


    }
    public void Dash()
    {
        // ---------------------------------  Dash Coroutine ----------------------------------
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
        if (Input.GetButtonDown("DashCustom") && dashUp)
        {

            StartCoroutine(Fonction_Dash());

            Animator_player.SetBool("BoolDash", true);

        }
        else if (Input.GetButtonUp("DashCustom"))
        {

            Animator_player.SetBool("BoolDash", false);

        };


    }

    public void Jump()
    {

        if (isGrounded)
        {
            coyoteTimeCount = coyoteTime;

        }
        else
        { 
            
            coyoteTimeCount -= Time.deltaTime;
           
        }
             // ------------------------- Jump --------------------------

        if (Input.GetButtonDown("JumpCustom")  /*&& coyoteTimeCount > 0f && nbSaut == 1f*/)
        {
            if (coyoteTimeCount > 0f || nbSaut == 1f)
            {

                rigidbody.velocity = Vector2.up * jump_speed;
                Debug.Log("1");
                nbSaut--;
                Debug.Log(nbSaut);


                Debug.Log(SecondJump);


            }





        }
        /* if (Input.GetButtonDown("JumpCustom") /*&& nbSaut >0 && !isGrounded && SecondJump == true)
         {
             rigidbody.velocity = Vector2.up * jump_speed;
             SecondJump = false;
             Debug.Log(nbSaut);
             Debug.Log("2");



         }*/

         if (isGrounded)
         {
                 nbSaut = 1;
         }




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


    public void actions()
    {
        // ---------------------------- Attaque ------------------------------
        void go_attack()
        {
            Animator_player.SetBool("BoolAttack", true);

        }


        // Coroutine d'immobilisation durant une attaque 
         IEnumerator Fonction_Attack()
         {
            CanAttack = false;
          
            mouvement_speed = 0;
             yield return new WaitForSeconds(0.6f);
             mouvement_speed = vitesseInit;
            yield return new WaitForSeconds(0.1f);
            CanAttack = true;


        }
        IEnumerator Fonction_Attack_Air()
        {
            CanAttack = false;

            yield return new WaitForSeconds(0.5f);
            CanAttack = true;


        }
        if (Input.GetButtonDown("AttackCustom")&& CanAttack == true)
        {

           go_attack();
          if (isGrounded)
          {
             StartCoroutine(Fonction_Attack());

          }
          if (coyoteTimeCount <=0)
          {
              StartCoroutine(Fonction_Attack_Air());

          }


        }
        else
        {

            Animator_player.SetBool("BoolAttack", false);

        }


    }
}
