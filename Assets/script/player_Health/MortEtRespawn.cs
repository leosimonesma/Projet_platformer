using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MortEtRespawn : MonoBehaviour
{
    private Vector2 Respawn;
    public float health = 3;
    [SerializeField] Animator Animator_player;

    private void Start()
    {
        Respawn = transform.position;
    }


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
    public void mort()
    {

        if (health <= 0)
        {

            // Animator_player.SetBool("BoolDeath",true );



        }




    }
    public void respawn()
    {

        transform.position = Respawn;
        // Animator_player.SetBool("BoolDeath",false );

    }



}
