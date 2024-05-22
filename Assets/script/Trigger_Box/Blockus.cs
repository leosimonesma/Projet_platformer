using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockus : MonoBehaviour
{
    [SerializeField] float MonsterHp = 2;
    [SerializeField] GameObject This;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        death();
    }
    public void loseHp()
    {
        MonsterHp--;
        Debug.Log("Je perd un Pv");

    }
    public void death()
    {
        if (MonsterHp <= 0)
        {
            This.SetActive(false);

        }
    }
}
