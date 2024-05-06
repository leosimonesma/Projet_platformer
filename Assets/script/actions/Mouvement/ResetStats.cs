using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetStats : MonoBehaviour
{
    [SerializeField] Player_Stats player;
    [SerializeField] GameObject collider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            player.setDashUp(false);
            player.setnbSaut(0);
            player.setCanDoubleJump(false);


        }




    }
    private void OnTriggerExit2D(Collider2D other)
    {

        collider.SetActive(false);


    }

}