using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Push : MonoBehaviour
{
    [SerializeField] Player_Stats player;
    [SerializeField] private GameObject msg;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.setCanPush(true);
            Debug.Log(player.getCanPush());
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
