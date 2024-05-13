using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockAttack : MonoBehaviour
{
    [SerializeField] Player_Stats player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.setCanAttack(true);
        }
    }

}
