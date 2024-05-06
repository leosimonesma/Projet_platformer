using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "PlayerStats/New PlayerStats Container")]
public class Player_Stats : ScriptableObject
{
    private bool CanAttack = true;
    private bool dashUp = false;
    private bool CanDoubleJump = false;
    private int nbSaut = 0;
    private float Health = 3;

    
    public bool getCanAttack()
    {
        return CanAttack;
    }
    public void setCanAttack(bool a)
    {
        CanAttack = a;
    }


    public bool getDashUp()
    {
        return dashUp;
    }
    public void setDashUp(bool d)
    {
        dashUp = d;
    }


    public bool getCanDoubleJump()
    {
        return CanDoubleJump;
    }
    public void setCanDoubleJump(bool dj)
    {
        CanDoubleJump = dj;
    }


    public int getnbSaut()
    {
        return nbSaut;
    }
    public void setnbSaut(int nbs)
    {
        nbSaut = nbs;
    }

    public float gethealth()
    {
        return Health;
    }
    public void sethealth(float h)
    {
        Health = h;
    }

}
