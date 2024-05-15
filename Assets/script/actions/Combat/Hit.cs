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
        }
        Debug.Log("Basic attack Is Performed");
    }

  /*  // trigger to inflict dmg to the monsters
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monsters"))
        {
            Debug.Log("j'ai touché");
           MonsterScript.loseHp();
        }
    }*/
}
