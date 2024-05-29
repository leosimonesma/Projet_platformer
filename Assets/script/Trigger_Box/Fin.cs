using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fin : MonoBehaviour
{
    [SerializeField] Animator Animator_Fin;
    public void Finito()
    {
        Animator_Fin.SetTrigger("TiggerFin");


    }
    public void LoadFinito()
    {
        SceneManager.LoadScene("SCN_Niveau4");


    }


}
