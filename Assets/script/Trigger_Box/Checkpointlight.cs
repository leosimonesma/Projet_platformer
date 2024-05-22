using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Checkpointlight : MonoBehaviour
{
    [SerializeField] Light2D CheckpointZone;
    [SerializeField] private AudioClip ActiveSound;
    bool alreadyDone= true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && alreadyDone == true)
        {
            Sound_Manager.instance.playSoundDXClip(ActiveSound, transform, 0.2f);
            CheckpointZone.intensity = 100;
            alreadyDone = false;


        }



    }

}
