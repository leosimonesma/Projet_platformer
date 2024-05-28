using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fin : MonoBehaviour
{
    [SerializeField] Animator Animator_Fin;
    public void Finito()
    {
        Animator_Fin.SetTrigger("TiggerFin");


    }

}
