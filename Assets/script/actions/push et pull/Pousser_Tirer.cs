using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
public class Pousser_Tirer : MonoBehaviour
{

    private int layerIndex;
    GameObject Player;
    bool Grab = false;
    private GameObject grabbedObject;
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameObject.layer == layerIndex)
            {
                Debug.Log("j'ai Grab");
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.SetParent(transform);
                Grab = true;

            }
            if (Grab ==true)
            {
                Debug.Log("je grab pas !");
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                

            }
        }



    }
}
