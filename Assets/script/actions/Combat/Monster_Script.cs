using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters_SCript : MonoBehaviour
{
    [SerializeField] float HitCheckRadius = 0.65f;
    [SerializeField] float AttackCheckRadius = 0.65f;
    [SerializeField] Transform HitCheck;
    [SerializeField] Transform AttackHox;
    [SerializeField] float MonsterHp = 2;
    public GameObject Monster;
    [SerializeField] LayerMask CollisionsLayers;
    [SerializeField] LayerMask CollisionsLayersAttack;
    [SerializeField] bool isHit = false;
    [SerializeField] bool recoveryTime = false;
    [SerializeField] Animator Animator_Monster;
    [SerializeField] bool DoHit;

    //methode to make the monster lose Hp
    public void loseHp()
    {
        if ( MonsterHp>0)
        {
            Animator_Monster.SetBool("BoolHurt", true);
            MonsterHp--;
            Debug.Log("Je perd un Pv");
            recoveryTime = true;
        }



    }
    public void finHurt() 
    {

        Animator_Monster.SetBool("BoolHurt", false);


    }
    // recovery time to prevent os of the monsters
    IEnumerator BeeingHit()
    {

        yield return new WaitForSeconds(1f);
        recoveryTime = false;
        finHurt();



    }
    // kill the monster when his Hp arrive a 0
    public void death()
    {
        if (MonsterHp <= 0)
        {
            Animator_Monster.SetBool("BoolDeath",true);
            Debug.Log("Je meurt !!");
          //  Monster.SetActive(false);

        }

    }
    public void destroyed()
    {
        Monster.SetActive(false);
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
    private void attack()
    {

        if (DoHit)
        {


            Animator_Monster.SetBool("BoolAttack", true);



        }
        else
        {
            Animator_Monster.SetBool("BoolAttack", false);


        }



    }

    public void finAttack()
    {

        //Animator_Monster.SetBool("BoolAttack", false);


    }




    void Start()
    {

    }


    void Update()
    {
        // "hitbox" of the monster
        isHit = Physics2D.OverlapCircle(HitCheck.position, HitCheckRadius, CollisionsLayers);
        DoHit = Physics2D.OverlapCircle(AttackHox.position, AttackCheckRadius, CollisionsLayersAttack);
        death();
        isHitted();
        attack();


    }
}
