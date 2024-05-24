using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReset : MonoBehaviour
{
    [SerializeField] Player_Stats player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.setDashUp(true);
        player.setnbSaut(1);
        player.setCanDoubleJump(true);


    }

}
