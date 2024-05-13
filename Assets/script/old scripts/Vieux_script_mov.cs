using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripttest : MonoBehaviour
{
    // creating floats I will use in the fonctions movement to make it easier if I want to change the speed of the movements. 
    [SerializeField] float testINT = 5f;
    [SerializeField] private Animator Player_Animator;
    [SerializeField] private SpriteRenderer Sprite_Renderer;
    bool Player_Run;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calling the fuction movement int the void uptdate in order to make move the object each frame when one of the selected key are pressed (up, down, right, left arrows and 0 on the key pad).
        Movement();
    }
    // the fonction I created to make move the object. 
    void Movement()
    {
        // Star of the run animation
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Translate(Vector3.right * testINT * Time.deltaTime);
            Player_Animator.SetBool("BoolRun", true);
            Sprite_Renderer.flipX = false;
        }
        //Changing the side of the sprite if moving the player to the left
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.Translate(Vector3.left * testINT * Time.deltaTime);
            Player_Animator.SetBool("BoolRun", true);
            Sprite_Renderer.flipX = true;
        }
        // end of the run animation
        else
        {
           
            Player_Animator.SetBool("BoolRun", false);

        }
        // start of attack animation 
        if (Input.GetKey(KeyCode.Keypad1))
        {
            Player_Animator.SetBool("BoolAttack", true);
            
        }
        //end of attack animation
        else
        {

            Player_Animator.SetBool("BoolAttack", false);

        }
        // start of crouch animation
        if (Input.GetKey(KeyCode.Keypad2))
        {
            Player_Animator.SetBool("BoolCrouch", true);

        }
        //end of crouch animation
        else
        {

            Player_Animator.SetBool("BoolCrouch", false);

        }

    }
}
