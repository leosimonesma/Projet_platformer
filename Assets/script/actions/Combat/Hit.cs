using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Monsters_SCript MonsterScript;


    private void Update()
    {
        
    }

    private void Start()
    {
        
    }

    // trigger to inflict dmg to the monsters
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monsters"))
        {
            Debug.Log("j'ai touch�");
           MonsterScript.loseHp();


        }


    }
}
