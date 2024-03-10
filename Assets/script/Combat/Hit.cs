using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Monsters MonsterScript;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monsters"))
        {
            Debug.Log("j'ai touché");
            MonsterScript.loseHp();


        }


    }
}
