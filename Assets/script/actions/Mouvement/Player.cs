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
        PlayerActions.horizontalMove = Input.GetAxis("Horizontal") * PlayerActions.mouvement_speed;

        if (PlayerActions.PlayerControl)
        {
            
           PlayerActions.mouvement(PlayerActions.horizontalMove * Time.fixedDeltaTime);
            if (isPushing.isGrabbing==true)
            {
                PlayerActions.mouvement_speed = 10f;


            }
           
            if (isPushing.isGrabbing == false)
            {
                PlayerActions.Jump();
                PlayerActions.Dash();
                PlayerActions.actions();
                PlayerActions.mouvement_speed = 40f;
            }

           
        }

    }


}
