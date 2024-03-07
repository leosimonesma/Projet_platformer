using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Mouvement : MonoBehaviour
{
    //-------------------- Initialisation des variables --------------
    [SerializeField] float mouvement_speed = 7f;
    [SerializeField] float speed = 50;
    float vitesseInit;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] GameObject player;
    [SerializeField] bool isGrounded = false;
    [SerializeField] int Hp = 3;
    [SerializeField] TextMeshProUGUI Health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // --------- Fonction de mouvement -------------
        Mouvement();
        Rotation();
        blessure();


    }
    //---------- Initialisation de la fonction "mouvement"  -------------
    void Mouvement()
    {
        // ------------- Initialisation des Fonctions de déplacements -----------------

        // ---------- Mouvement gauche --------
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(Vector3.left * mouvement_speed * Time.deltaTime, Space.World);


        }
        // ---- Mouvement droite ----------
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Translate(Vector3.right * mouvement_speed * Time.deltaTime, Space.World);

        }
        // ---- Mouvement Haut ----------
        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.Translate(Vector3.up * mouvement_speed * Time.deltaTime, Space.World);

        }
        // ---- Mouvement Bas ----------
        if (Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(Vector3.down * mouvement_speed * Time.deltaTime, Space.World);

        }




    }
    // ------------- Contact Check -------------
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Sol"))
        {
            isGrounded = true;
            Hp--;
            Health.text = Hp.ToString();
            isGrounded = false;
        }
    
    }


   /* void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Sol"))
        {
            isGrounded = false;
        }
    }*/
    // --------------- Perte Hp et Game Over ---------------
   void blessure()
    {
       
        if (Hp == 0) {
            SceneManager.LoadScene("Exam_Game_Over");
        }
    }
  
    // ------------- Rotation du Player --------------
     void Rotation ()
      {
        transform .Rotate (Vector3.forward,speed* Time.deltaTime, Space.Self);

    }
    // --------------- Regain de Hp -----------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hp up") && Hp <3)
        {
            Hp = 3;
            Health.text = Hp.ToString();
            Debug.Log("Hp = 3");

        }

    }
}