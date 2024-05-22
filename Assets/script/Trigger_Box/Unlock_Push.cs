using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Push : MonoBehaviour
{
    [SerializeField] Player_Stats player;
    [SerializeField] private GameObject msg;
    [SerializeField] private bool active = true; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && active == true)
        {
            player.setCanPush(true);
            active = false;
         
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            msg.gameObject.SetActive(true);
        }
    }
}
