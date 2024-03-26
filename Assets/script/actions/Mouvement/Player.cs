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
        // le ispushing permet d'entraver le joueur quand il push un objet
        if (isPushing.isGrabbing == false)
        {
            PlayerActions.horizontalMove = Input.GetAxis("Horizontal") * PlayerActions.mouvement_speed;


        }
        else if (isPushing.isGrabbing == true)
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

    }


}
