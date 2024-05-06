using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Checkpointlight : MonoBehaviour
{
    [SerializeField] Light2D CheckpointZone;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            CheckpointZone.intensity = 100;



        }



    }

}
