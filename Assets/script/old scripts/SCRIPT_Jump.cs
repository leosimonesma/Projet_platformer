using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] float velocity = 10f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator Player_Animator;


    // Start is called before the first frame update
    void Start()
    {
        //specifing the rigid body 
        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //start of the jump
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            rigidbody.velocity = Vector2.up * velocity;
            Player_Animator.SetBool("BoolJump", true);
        }
        // end of the jump
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Player_Animator.SetBool("BoolJump", false);
        }
    }
}
