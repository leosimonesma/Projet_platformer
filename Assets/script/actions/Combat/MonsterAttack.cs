using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField]  MortEtRespawn playerdmg;
    public Player PlayerMouvement;

    private void Update()
    {

    }

    private void Start()
    {

    }

    //trigger to allow the monster to inflict dmg to the player

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            playerdmg.Knockback_Duration = playerdmg.Knockback_Total_Time;
            Debug.Log("j'ai touché");
            if (other.transform.position.x <= transform.position.x)
            {
                playerdmg.KnockFromRight = true;

            }
            if (other.transform.position.x >= transform.position.x)
            {
                playerdmg.KnockFromRight = false;

            }
            playerdmg.hitted();
            playerdmg.knockback();




        }


    }
}
