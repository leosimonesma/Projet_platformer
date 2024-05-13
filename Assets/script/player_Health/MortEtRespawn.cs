using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MortEtRespawn : MonoBehaviour
{

    //------------------ death and respawn -------------
    private Vector2 Respawn;
    [SerializeField] Player_Stats player;
    [SerializeField] Animator Animator_player;
    [SerializeField] public GameObject[] Pv;
    public float health = 3f;
    bool pv1 = true;
    bool pv2 = true;
    bool pv3 = true;

    // ---------------- knockback ----------------------
    public float Knockback_Strenght = 20;
    public float Knockback_Duration = 0.2f;
    public float Knockback_Total_Time = 0.2f;
    public bool KnockFromRight;
    public Player_Mouvements PlayerActions;

    private void Awake()
    {
        //pvloss();
    }

    private void Start()
    {
        Respawn = transform.position;
        // set les pv a 3 
    }
    private void Update()
    {


        mort();
        pvloss();
        pvrecup();


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
            health--;
            transform.position = Respawn;
            player.sethealth(health);
            
            Debug.Log(health);

        }


    }
    public void stophurt()
    {
        Animator_player.SetBool("boolHurt", false);

    }
    // lose health (called in the monster attack script
    public void hitted()
    {
        health--;
        player.sethealth(health);
            
        Animator_player.SetBool("boolHurt", true);
        Debug.Log(health);


    }
    //death of the player when hp = 0
    public void mort()
    {

        if (player.gethealth() <= 0)
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
    //UI interactive des pv pour faire disparaitre les coeurs et les faires réaparaitre
    public void pvloss()
    {
        if (player.gethealth() < 1)
        {

            Pv[0].gameObject.SetActive(false);
            pv1 = false;

        }
        else if(player.gethealth() < 2) 
        {

            Pv[1].gameObject.SetActive(false);
            pv2 = false;

        }
        else if (player.gethealth() < 3)
        {

            Pv[2].gameObject.SetActive(false);
            pv3 = false;
            Debug.Log(player.gethealth());

        }



    }
    private void pvrecup()
    {
        if (player.gethealth() == 2 && pv2 == false)
        {

            Pv[1].gameObject.SetActive(true);


        }
        else if (player.gethealth() == 3 && pv3 == false)
        {

            Pv[2].gameObject.SetActive(true);


        }





    }




}
