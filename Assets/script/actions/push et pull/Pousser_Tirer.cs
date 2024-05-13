using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
public class Pousser_Tirer : MonoBehaviour
{

  //  [SerializeField] float GrabCheckRadius = 0.65f;
//    [SerializeField] Transform GrabCheck;
 //  public bool isGrabbing = false;
  //  [SerializeField] LayerMask CollisionsLayers;
   // [SerializeField] bool isGrab = false;
    [SerializeField] GameObject player;
    private Transform PlayerTransform;
    [SerializeField] Transform ObjectTransform;
    private const float interactDistance = 4f;
    public Player playerstats;
    private void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void Update()
    {
        if (Input.GetButtonDown("DialogueCustom") && IsWithinGrabtDistance())
        {
            Debug.Log("j'ai Grab");
            ObjectTransform.GetComponent<Rigidbody2D>().isKinematic = true;
            ObjectTransform.transform.SetParent(PlayerTransform);
            

        }
       else if (Input.GetButtonDown("DialogueCustom"))
        {
            Debug.Log("je grab pas !");
            ObjectTransform.GetComponent<Rigidbody2D>().isKinematic = false;
            ObjectTransform.transform.SetParent(null);
            


        }
        if (IsWithinGrabtDistance())
        {

           // Debug.Log("je peux grab");

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
