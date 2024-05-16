using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.InputSystem.DefaultInputActions;
using UnityEngine.Rendering.Universal;

public class HealPoint : MonoBehaviour
{
    public SpriteRenderer InteractSprite;
    private Transform PlayerTransform;
    private const float interactDistance = 2f;
    public MortEtRespawn PlayerHealth;
    [SerializeField] float nbHeal = 1;
    [SerializeField] Light2D healzone;
    [SerializeField] Player_Stats player;




    private void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {


        if (Input.GetButtonDown("DialogueCustom") && IsWithinInteractDistance())
        {

            Heal();

        }
        if (InteractSprite.gameObject.activeSelf && !IsWithinInteractDistance())
        {
            // ----------------set interraction sprite OFF ----------------
            InteractSprite.gameObject.SetActive(false);



        }
        else if (!InteractSprite.gameObject.activeSelf && IsWithinInteractDistance()&& nbHeal ==1)
        {
            //----------- set interraction sprite ON ------------

            InteractSprite.gameObject.SetActive(true);
        }


    }

   


    // ----------------check distance between the player and the NPC-------------
    private bool IsWithinInteractDistance()
    {

        if (Vector2.Distance(PlayerTransform.position, transform.position) < interactDistance)
        {
            return true;
        }
        else
        {
            return false;


        }


    }
    private void Heal()
    {

        if (PlayerHealth.health < 3 && nbHeal ==1)
        {


            PlayerHealth.health++;
            player.sethealth(PlayerHealth.health);
            Debug.Log(PlayerHealth.health);
            nbHeal = 0;
            healzone.intensity = 0;



        }

    }

}
