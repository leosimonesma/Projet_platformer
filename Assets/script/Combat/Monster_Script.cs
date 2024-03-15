using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters_SCript : MonoBehaviour
{

    [SerializeField] float MonsterHp = 2;
    public GameObject Monster;


    public void loseHp()
    {

        MonsterHp--;
        Debug.Log("Je perd un Pv");
    }
    public void death()
    {
        if (MonsterHp <= 0)
        {
            Monster.SetActive(false);
            Debug.Log("Je meurt !!");

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Attack"))
        {
            Debug.Log("j'ai touché");
           loseHp();
            
        }


    }





    void Start()
    {

    }


    void Update()
    {
        death();
    }
}
