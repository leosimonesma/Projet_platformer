using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAndDoubleJumpUnlock : MonoBehaviour
{
    [SerializeField] Player_Stats player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            player.setDashUp(true);
            player.setnbSaut(1);
            player.setCanDoubleJump(true);


        }




    }

}
