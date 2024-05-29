using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockAttack : MonoBehaviour
{
    [SerializeField] Player_Stats player;
    [SerializeField] private bool active = true;
    [SerializeField] private GameObject msg;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && active == true)
        {
            player.setCanAttack(true);
            active = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        msg.SetActive(true);


    }

}
