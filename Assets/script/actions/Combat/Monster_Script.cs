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

    //methode to make the monster lose Hp and die
    public void loseHp()
    {
        MonsterHp--;
       
        
            Animator_Monster.SetBool("BoolHurt", true);
            
            Debug.Log("Je perd un Pv");
            StartCoroutine(BeeingHit());


        
       if (MonsterHp <= 0)
       {
            Animator_Monster.SetBool("BoolDeath", true);
            StartCoroutine(Dying());
            Debug.Log("Je meurt !!");

       }

    }

    // coroutines to stop the hurt animation and the death animation at the right time 
    IEnumerator BeeingHit()
    {

        yield return new WaitForSeconds(0.4f);
        Animator_Monster.SetBool("BoolHurt", false);



    }
    IEnumerator Dying()
    {

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);



    }
    // kill the monster when his Hp arrive a 0
    public void death()
    {
        if (MonsterHp <= 0)
        {
            MonsterHp--;
            Animator_Monster.SetBool("BoolDeath",true);
            StartCoroutine(Dying());

        }

    }
    public void destroyed()
    {
        Debug.Log("mange mes couilles animation de merde");
    }
    //Attack Animation
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
        DoHit = Physics2D.OverlapCircle(AttackHox.position, AttackCheckRadius, CollisionsLayersAttack);
       // death();
        attack();


    }
}
