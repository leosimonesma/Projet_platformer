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
    [SerializeField] MonsterMouvement mouvement;
    public bool IsAlive = true;
    [SerializeField] private AudioClip SwingSound;

    //methode to make the monster lose Hp and die
    public void loseHp()
    {
        MonsterHp--;
        StartCoroutine(blesse());
        Debug.Log("Je perd un Pv");

    }

    // coroutines to stop the hurt animation and the death animation at the right time 
    IEnumerator blesse()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.09f);
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
    // kill the monster when his Hp arrive a 0
    public void death()
    {
        if (MonsterHp <= 0 && IsAlive == true)
        {
            mouvement.IsHitting = true;
            mouvement.IsChasing = false;
            IsAlive = false;
            Animator_Monster.SetTrigger("TriggerDeath");
            Debug.Log("Je meurt !!");
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
            Sound_Manager.instance.playSoundDXClip(SwingSound, transform, 0.05f);
            mouvement.IsHitting = true;
        }
        else
        {
            Animator_Monster.SetBool("BoolAttack", false);
            mouvement.IsHitting = false;
        }
    }
    void Update()
    {
        // "hitbox" of the monster
        DoHit = Physics2D.OverlapCircle(AttackHox.position, AttackCheckRadius, CollisionsLayersAttack);
        death();
        attack();
    }
}
