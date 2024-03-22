using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MortEtRespawn : MonoBehaviour
{
    private Vector3 Respawn;




    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            transform.position = Respawn;
        }
    }



}
