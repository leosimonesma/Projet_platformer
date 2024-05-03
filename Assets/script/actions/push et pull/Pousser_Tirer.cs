using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
public class Pousser_Tirer : MonoBehaviour
{

    [SerializeField] float GrabCheckRadius = 0.65f;
    [SerializeField] Transform GrabCheck;
    [SerializeField] bool isGrabbing = false;
    [SerializeField] LayerMask CollisionsLayers;
   // [SerializeField] bool isGrab = false;
    [SerializeField] GameObject player;
    private void Start()
    {
        
    }

     void OnTriggerStay2D(Collider2D other)
     {
        if (other.CompareTag("Objects"))
        {

            Debug.Log("je suis en range");


            if (Input.GetButtonDown("DialogueCustom") && !isGrabbing)
            {
                Debug.Log("j'ai Grab");
                //other.GetComponent<Rigidbody2D>().isKinematic = true;
                other.transform.SetParent(transform);
                isGrabbing = true;
            }
            else if (Input.GetButtonDown("DialogueCustom") && isGrabbing)
            {
                Debug.Log("je grab pas !");
                // other.GetComponent<Rigidbody2D>().isKinematic = false;
                other.transform.SetParent(null);
                other = null;
                isGrabbing = false;


            }


        }









    }


}
