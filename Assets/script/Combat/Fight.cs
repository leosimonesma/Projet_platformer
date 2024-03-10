using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public GameObject Hit;
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
    
    public void Start()
    {
        




    }
    public void Update()
    {

       

    }





}
