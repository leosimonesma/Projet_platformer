using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class pushetpull : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform raypoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(raypoint.position, transform.right, rayDistance);


        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            Debug.Log("je lance le ray");
            //grab object
            if (Keyboard.current.tKey.wasPressedThisFrame && grabbedObject == null)
            {
                Debug.Log("je grab");
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            //release object
            else if (Keyboard.current.tKey.wasPressedThisFrame)
            {
                Debug.Log("je grab pas !");
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;

            }
        }



        Debug.DrawRay(raypoint.position, transform.right * rayDistance);

    }
}
