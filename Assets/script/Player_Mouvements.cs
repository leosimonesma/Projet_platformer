using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mouvements : MonoBehaviour
{
    //-------------------- Initialisation des variables --------------
    [SerializeField] float mouvement_speed = 5f;
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


    // Start is called before the first frame update
    void Start()
    {

        vitesseInit = mouvement_speed;

    }


    // Update is called once per frame
    void Update()
    {

        // --------------------------------- Fonction de mouvement -------------------------------
        if (PlayerControl)
        {
            mouvement();
        }


        //  -------------------------- Fonction d'actions --------------------------
        actions();






    }
    // ----------------------------- player stop animation -------------------------------- 
    public void stopMouvement()
    {
        PlayerControl = false;
        Animator_player.SetBool("BoolRun", false);
        Debug.Log("frezze");
    }
    public void playMouvement()
    {
        PlayerControl = true;

    }
    // --------------------------------- IsGrounded -----------------------------------
    /* void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Sol"))
         {
             isGrounded = true;
         }
     }
     void OnCollisionExit2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Sol"))
         {
             isGrounded = false;
         }
     }*/
    private void FixedUpdate()
    {
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

    //--------------------------------------- Initialisation de la fonction "mouvement"  -----------------------------------
    void mouvement()
    {
        // ------------------------------ Initialisation des Fonctions de d�placements ------------------------------------
       // if (CanMove) {


          //  move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            //rigidbody.velocity = new Vector2(move.x * mouvement_speed, rigidbody.velocity.y);
            // ------------------------- Mouvement gauche -----------------------
           if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log(rigidbody.velocity);
                transform.Translate(Vector2.left * mouvement_speed * Time.deltaTime);
                Animator_player.SetBool("BoolRun", true);
                sprite_renderer.flipX = true;

            }
            // -------------------------- Mouvement droite ------------------------
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                transform.Translate(Vector2.right * mouvement_speed * Time.deltaTime);
                Animator_player.SetBool("BoolRun", true);
                sprite_renderer.flipX = false;

            }


            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {

                Animator_player.SetBool("BoolRun", false);


            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {

                Animator_player.SetBool("BoolRun", false);

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


            // pause/dur�e
            yield return new WaitForSeconds(dash_duration);


            //Retablisement de la vitesse enregistr�e�
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
