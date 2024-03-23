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
    [SerializeField] bool Grab = false;
    [SerializeField] LayerMask CollisionsLayers;
    [SerializeField] bool isGrab = false;
    // public GameObject grabbedObject;
    private void Start()
    {
        
    }
     void OnTriggerStay2D(Collider2D other)
     {
           if (Input.GetKeyDown(KeyCode.E))
           {
               if (other.CompareTag("Objects"))
               {
                if (!Grab)
                {
                    Debug.Log("j'ai Grab");
                    other.transform.SetParent(transform);
                    Grab = true;
                }
                else
                {
                    Debug.Log("je grab pas !");
                    other.transform.SetParent(null);
                    Grab = false;


                }


               }

           }




     }


}
