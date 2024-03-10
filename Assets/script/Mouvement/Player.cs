using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public Player_Mouvements PlayerActions;


    void Update()
    {
        // ----------------------------- Appel Fonction de Mouvement --------------------------------
        PlayerActions.horizontalMove = Input.GetAxisRaw("Horizontal") * PlayerActions.mouvement_speed;

        if (PlayerActions.PlayerControl)
        {
           PlayerActions.mouvement(PlayerActions.horizontalMove * Time.fixedDeltaTime);
            PlayerActions.Jump();
            PlayerActions.Dash();
            PlayerActions.actions();
        }

    }


}
