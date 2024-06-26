using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public Player_Mouvements PlayerActions;
    public pushetpull isPushing;


    void Update()
    {
        // ----------------------------- Appel Fonction de Mouvement --------------------------------
      
        // The ispushing allow to reduce the speed when the player is pushing something
        if (isPushing.isGrabbing == false )
        {
            PlayerActions.horizontalMove = Input.GetAxis("Horizontal") * PlayerActions.mouvement_speed;


        }
        else if (isPushing.isGrabbing == true )
        {

            PlayerActions.horizontalMove = Input.GetAxis("Horizontal") * PlayerActions.mouvement_grab;
        }


        if (PlayerActions.PlayerControl)
        {
            
           PlayerActions.mouvement(PlayerActions.horizontalMove * Time.fixedDeltaTime);


            if (isPushing.isGrabbing == false)
            {
                PlayerActions.Jump();
                PlayerActions.Dash();
                PlayerActions.actions();
    
            }

           
        }
        Tire();
    }
    private void Tire()
    {

        if(isPushing.isGrabbing == true && PlayerActions.horizontalMove < 0)
        {
            PlayerActions.Animator_player.SetBool("BoolTire", true);

        }
        else
        {
            PlayerActions.Animator_player.SetBool("BoolTire", false);

        }
    }

}
