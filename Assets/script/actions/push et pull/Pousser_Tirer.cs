using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor.PackageManager;
using UnityEngine;
//using UnityEngine.InputSystem;
public class Pousser_Tirer : MonoBehaviour
{

  //  [SerializeField] float GrabCheckRadius = 0.65f;
    [SerializeField] Transform Grabpos;
 //  public bool isGrabbing = false;
  //  [SerializeField] LayerMask CollisionsLayers;
   // [SerializeField] bool isGrab = false;
    [SerializeField] GameObject player;
    private Transform PlayerTransform;
    private const float interactDistance = 1f;
    [SerializeField] Transform hitboxposition;
    [SerializeField] Vector2 hitboxsize;
    [SerializeField] LayerMask _layermask;
    public bool isGrabbing = false;
    private float Knockback_Strenght = 20;



    private void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void Update()
    {


    }
    public void Attack_Normal()
    {
        Collider2D[] Player_Hitbox = Physics2D.OverlapBoxAll(hitboxposition.position, hitboxsize, _layermask);

        foreach (var obj in Player_Hitbox)
        {

            if (obj.tag == "Objects" && Input.GetButton("DialogueCustom"))
            {
                if (Vector2.Distance(PlayerTransform.position, obj.transform.position) < interactDistance)
                {
                    obj.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-Knockback_Strenght, Knockback_Strenght);

                }
                Debug.Log("je grab");
                obj.GetComponent<Rigidbody2D>().isKinematic = true;
                obj.transform.SetParent(transform);
                isGrabbing = true;


            }
            else if (Input.GetButtonDown("DialogueCustom") && isGrabbing == true)
            {
                Debug.Log("je grab pas !");
                obj.GetComponent<Rigidbody2D>().isKinematic = false;
                obj.transform.SetParent(null);
                isGrabbing = false;



            }

        }
       
    }



    private bool IsWithinGrabtDistance()
    {

        if (Vector2.Distance(PlayerTransform.position, transform.position) < interactDistance)
        {
            return true;
        }
        else
        {
            return false;


        }


    }


}
