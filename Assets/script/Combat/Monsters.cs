using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{

    [SerializeField] float MonsterHp = 2;
    GameObject Monster;

    public void loseHp()
    {

        MonsterHp--;
        Debug.Log("Je perd un Pv");
    }
    public void death()
    {
        if (MonsterHp <=0)
        {
            Monster.SetActive(false);
            Debug.Log("Je meurt !!");

        }

    }




    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
