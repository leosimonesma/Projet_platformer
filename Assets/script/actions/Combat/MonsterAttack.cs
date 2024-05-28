using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] public  MortEtRespawn playerdmg;
    [SerializeField] public Player PlayerMouvement;
    [SerializeField] Transform hitboxposition;
    [SerializeField] Vector2 hitboxsize;
    [SerializeField] LayerMask _layermask;

    private void FixedUpdate()
    {
        

    }

    private void Start()
    {

    }

    //trigger to allow the monster to inflict dmg to the player

    private void DoDMG()
    {
        Collider2D[] Player_Hitbox = Physics2D.OverlapBoxAll(hitboxposition.position, hitboxsize, _layermask);

        foreach (var Enemy in Player_Hitbox)
        {
            playerdmg.Knockback_Duration = playerdmg.Knockback_Total_Time;
            Debug.Log("j'ai touché");
            if (Enemy.transform.position.x <= transform.position.x && Enemy.tag == "Player")
            {
                playerdmg.KnockFromRight = true;

            }
            if (Enemy.transform.position.x >= transform.position.x && Enemy.tag == "Player")
            {
                playerdmg.KnockFromRight = false;

            }
            if (Enemy.tag == "Player")
            {
              playerdmg.hitted();
              playerdmg.knockback();
            }
        }
    }
}
