using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Stats : MonoBehaviour
{
    [SerializeField] Player_Stats player;
    [SerializeField] GameObject Box;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            player.setDashUp(true);
            player.setnbSaut(0);
            player.setCanDoubleJump(true);
            player.setCanAttack(true);
            player.sethealth(3);
            player.setIsAlive(true);
            player.setCanPush(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Box.SetActive(false);
    }
}
