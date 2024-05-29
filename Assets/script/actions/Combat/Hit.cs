using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] Transform hitboxposition;
    [SerializeField] Vector2 hitboxsize;
    [SerializeField] LayerMask _layermask;

    public void Attack_Normal()
    {
        Collider2D[] Player_Hitbox = Physics2D.OverlapBoxAll(hitboxposition.position, hitboxsize, _layermask);

        foreach (var Enemy in Player_Hitbox)
        {
            if (Enemy.tag == "Monsters")
            {

                Enemy.GetComponent<Monsters_SCript>().loseHp(); 
            }

            if (Enemy.tag == "Fin")
            {

                Enemy.GetComponent<Fin>().Finito();
            }

        }
    }
}
