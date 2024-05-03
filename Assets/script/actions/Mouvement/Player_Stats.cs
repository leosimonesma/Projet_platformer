using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "PlayerStats/New PlayerStats Container")]
public class Player_Stats : ScriptableObject
{
    private bool CanAttack = true;
    private bool dashUp = true;
    private bool CanDoubleJump = true;
    private int nbSaut = 1;
    private float Health = 3;

    
    public bool getCanAttack()
    {
        return CanAttack;
    }
    public void setCanAttack(bool a)
    {
       a = getCanAttack();
    }


    public bool getDashUp()
    {
        return dashUp;
    }
    public void setDashUp(bool d)
    {
        d = getDashUp();
    }


    public bool getCanDoubleJump()
    {
        return CanDoubleJump;
    }
    public void setCanDoubleJump(bool dj)
    {
        dj = getCanDoubleJump();
    }


    public int getnbSaut()
    {
        return nbSaut;
    }
    public void setnbSaut(int nbs)
    {
        nbs = getnbSaut();
    }

    public float gethealth()
    {
        return Health;
    }
    public void sethealth(float nbs)
    {
        nbs = gethealth();
    }

}
