using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MortEtRespawn : MonoBehaviour
{

    //------------------ death and respawn -------------
    private Vector2 Respawn;
    public float health = 3;
    [SerializeField] Animator Animator_player;

    // ---------------- knockback ----------------------
    public float Knockback_Strenght = 20;
    public float Knockback_Duration = 0.2f;
    public float Knockback_Total_Time = 0.2f;
    public bool KnockFromRight;
    public Player_Mouvements PlayerActions;



    private void Start()
    {
        Respawn = transform.position;
    }
    private void Update()
    {


        mort();


    }

    // bring the player back to the last checkpoint when hitting a deathbox and make him lose 1 hp
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            

            Respawn = transform.position;


        }
        else if (other.gameObject.CompareTag("DeathPoint"))
        {

            transform.position = Respawn;
            health--;
            Debug.Log(health);

        }


    }
    // lose health (called in the monster attack script
    public void hitted()
    {

        health--;
        Debug.Log(health);


    }
    //death of the player when hp = 0
    public void mort()
    {

        if (health <= 0)
        {


            SceneManager.LoadScene("SCN_Niveau1");
            // Animator_player.SetBool("BoolDeath",true );



        }




    }
    //keep in memory the checkpoint position
    public void respawn()
    {

        transform.position = Respawn;
        // Animator_player.SetBool("BoolDeath",false );

    }
    //method to knocback the player when he is hitted depending of where he is hitted from 
    public void knockback()
    {
        if (KnockFromRight)
        {
            PlayerActions.rigidbody.velocity = new Vector2(-Knockback_Strenght, Knockback_Strenght);
        }
        if (!KnockFromRight)
        {
            PlayerActions.rigidbody.velocity = new Vector2(Knockback_Strenght, Knockback_Strenght);
        }
        Knockback_Duration -= Time.deltaTime;


    }




}
