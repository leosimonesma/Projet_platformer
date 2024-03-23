using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters_SCript : MonoBehaviour
{
    [SerializeField] float HitCheckRadius = 0.65f;
    [SerializeField] Transform HitCheck;
    [SerializeField] float MonsterHp = 2;
    public GameObject Monster;
    [SerializeField] LayerMask CollisionsLayers;
    [SerializeField] bool isHit = false;
    [SerializeField] bool recoveryTime = false;

    //methode to make the monster lose Hp
    public void loseHp()
    {

        MonsterHp--;
        Debug.Log("Je perd un Pv");
        recoveryTime = true;

    }
    // recovery time to prevent os of the monsters
    IEnumerator BeeingHit()
    {

        yield return new WaitForSeconds(1f);
        recoveryTime = false;


    }
    // kill the monster when his Hp arrive a 0
    public void death()
    {
        if (MonsterHp <= 0)
        {
            Monster.SetActive(false);
            Debug.Log("Je meurt !!");

        }

    }
// methode that combine the loss of Hp and the recovery time
    void isHitted()
    {
        if (isHit && !recoveryTime)
        {
            loseHp();
             StartCoroutine(BeeingHit());

        }

    }





    void Start()
    {

    }


    void Update()
    {
        // "hitbox" of the monster
        isHit = Physics2D.OverlapCircle(HitCheck.position, HitCheckRadius, CollisionsLayers);
        death();
        isHitted();


    }
}
