using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAndDoubleJumpUnlock : MonoBehaviour
{
    [SerializeField] Player_Stats player;
    [SerializeField] bool active = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && active == true)
        {

            player.setDashUp(true);
            player.setnbSaut(1);
            player.setCanDoubleJump(true);
            active = false;
        }




    }

}
