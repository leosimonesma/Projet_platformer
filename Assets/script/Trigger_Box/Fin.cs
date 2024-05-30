using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fin : MonoBehaviour
{
    [SerializeField] Animator Animator_Fin;
    [SerializeField] Animator Animator_Transition;
    public void Finito()
    {
        Animator_Fin.SetTrigger("TiggerFin");


    }
    public void LoadFinito()
    {
        Animator_Transition.SetTrigger("Transition_Trigger_SNC_04");


    }


}
