using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rez : MonoBehaviour
{
    [SerializeField] Player_Stats joueur;
    [SerializeField] GameObject symboleMort;
    [SerializeField] GameObject perso;
    void Update()
    {

        death();



    }
    IEnumerator Mort()
    {
        symboleMort.SetActive(true);
        
        perso.SetActive(false);
        yield return new WaitForSeconds(2f);
        symboleMort.SetActive(false);
        SceneManager.LoadScene("SCN_Niveau1");
        joueur.setIsAlive(true);
        joueur.sethealth(3);

    }
    private void death()
    {
       if (joueur.getIsAlive()== false) {

            StartCoroutine(Mort());

        }


    }
}
