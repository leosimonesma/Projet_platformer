using System.Collections;
using UnityEngine;

public class Player_Mouvements : MonoBehaviour
{
    //-------------------- Initialisation des variables --------------


    // ----------------------- Mouvement --------------------
    public float mouvement_speed = 45f;
    public float mouvement_grab = 10f;
    public float horizontalMove = 0f;
    float vitesseInit;
    [SerializeField] bool CanMove = true;
    public bool PlayerControl = true;
    private Vector3 m_Velocity = Vector3.zero;
    private bool FacingRight = true;
    [Range(0, .3f)][SerializeField] private float MovementSmoothing = .05f;
    public pushetpull isPushing;
    [SerializeField] Player_Stats player;


    // -------------------- Jump -------------------
    [SerializeField] float jump_speed = 10f;
    [SerializeField] bool isGrounded = false;
   // [SerializeField] int nbSaut = 1;
    [SerializeField] float groundCheckRadius;
    [SerializeField] Transform groundCheck;
    [SerializeField] float coyoteTime = 0.5f;
    private float coyoteTimeCount;
    [SerializeField] LayerMask CollisionsLayers;
    [SerializeField] GameObject isGroundedCricle;
    [SerializeField] bool SecondJump = false;
    [SerializeField] private AudioClip SecondJumpSound;

    // ---------------- Dash ------------------------
    [SerializeField] float dash_speed = 2f;
    [SerializeField] float dash_duration = 0.1f;
    [SerializeField] float couldown = 3f;
    [SerializeField] bool dashUp = true;
    [SerializeField] private AudioClip DashSound;

    // ------------- Animations ----------------------------
    [SerializeField] public Animator Animator_player;
    [SerializeField] SpriteRenderer sprite_renderer;
    public Rigidbody2D rigidbody;


  // ------------------ Actions -------------------------
    [SerializeField] bool CanAttack = true;
    [SerializeField] private AudioClip[] SwingSounds;




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
        PlayerControl = false;
        horizontalMove = 0f;    
        rigidbody.velocity = Vector3.zero;
        
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
       
        if (horizontalMove > 0 && FacingRight)
        {
            Animator_player.SetBool("BoolRun", true);
            sprite_renderer.flipX = false;
        }
        else if (horizontalMove < 0 && !FacingRight)
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
        if (move > 0 && !FacingRight && isPushing.isGrabbing == false)
        {
 
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right
        else if (move < 0 && FacingRight && isPushing.isGrabbing == false)
        {
            Flip();
        }

    }
    public void Dash()
    {
        // ---------------------------------  Dash Coroutine ----------------------------------
        IEnumerator Fonction_Dash()
        {
            //CanMove = false;
           // dashUp = false;
            player.setDashUp(false);
            //multiplication de la vitesse
            mouvement_speed = mouvement_speed * dash_speed;


            // pause/dur�e
            yield return new WaitForSeconds(dash_duration);


            //Retablisement de la vitesse enregistr�e�
            mouvement_speed = vitesseInit;

            //couldown
            yield return new WaitForSeconds(couldown);
          //  dashUp = true;
            player.setDashUp(true);


        }
        // --------------------------------- Dash ----------------------------------
        if (Input.GetButtonDown("DashCustom") && player.getDashUp())
        {

            StartCoroutine(Fonction_Dash());
            Sound_Manager.instance.playSoundDXClip(DashSound, transform, 0.2f);

            Animator_player.SetBool("BoolDash", true);

        }
        else
        {

            Animator_player.SetBool("BoolDash", false);

        };

    }

    public void DoubleJumpstart()
    {
        Animator_player.SetBool("BoolSecondJump", true);
        Sound_Manager.instance.playSoundDXClip(SecondJumpSound, transform, 0.2f);
    }
    public void DoubleJumpEnd()
    {
        Animator_player.SetBool("BoolSecondJump", false);
    }

    public void Jump()
    {

        if (isGrounded)
        {
            coyoteTimeCount = coyoteTime;
           // Debug.Log("reset c time");

        }
        else
        { 
            
            coyoteTimeCount -= Time.deltaTime;
           
        }
             // ------------------------- Jump --------------------------

        if (Input.GetButtonDown("JumpCustom"))
        {
            if (isGrounded || player.getnbSaut() == 1f)
            {
                if (player.getnbSaut() == 1 && !isGrounded)
                {
                    DoubleJumpstart();

                }
                rigidbody.velocity = Vector2.up * jump_speed;
                //Debug.Log("1");
                //nbSaut--;
                player.setnbSaut(0);
               


               // Debug.Log(SecondJump);


            }





        }

         if (isGrounded && player.getCanDoubleJump())
         {
                 
            player.setnbSaut(1);
         }




    }

    // ------------------------- Flipping the player -------------------------------
    private void Flip()
    {
        
       FacingRight = !FacingRight;

        
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
            player.setCanAttack(false);
          
            mouvement_speed = 0;
             yield return new WaitForSeconds(0.6f);
             mouvement_speed = vitesseInit;
            yield return new WaitForSeconds(0.1f);
            player.setCanAttack(true);


        }
        IEnumerator Fonction_Attack_Air()
        {
            player.setCanAttack(false);

            yield return new WaitForSeconds(0.5f);
            player.setCanAttack(true);

        }
        if (Input.GetButtonDown("AttackCustom")&& player.getCanAttack())
        {
            Sound_Manager.instance.playSoundRandomDXClip(SwingSounds, transform, 0.2f);
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
