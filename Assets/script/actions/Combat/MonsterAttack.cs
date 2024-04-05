using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField]  MortEtRespawn playerdmg;

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
            Debug.Log("j'ai touché");
            playerdmg.hitted();


        }


    }
}
