using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetStats : MonoBehaviour
{
    [SerializeField] Player_Stats player;
    [SerializeField] GameObject Box;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            player.setDashUp(false);
            player.setnbSaut(0);
            player.setCanDoubleJump(false);
            player.setCanAttack(false);
            player.sethealth(3);
            player.setIsAlive(true);
            player.setCanPush(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Box.SetActive(false);
    }

}