using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public GameObject Hit;
    public GameObject MonstersHitbox;
    public Monsters MonsterScript;

    public void hit()
    {

        Hit.SetActive(true);
        Debug.Log("j'hit");

    }
    public void unhit()
    {

        Hit.SetActive(false);
        Debug.Log("j'hit plus");

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monsters"))
        {

            MonsterScript.loseHp();


        }


    }
    public void Start()
    {
        




    }
    public void Update()
    {
        


    }





}
