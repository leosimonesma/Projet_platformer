using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject ReglagesMenuUI;
    public GameObject MainMenuUI;
    public void ButtonPlay()
    {
        SceneManager.LoadScene("SCN_Niveau1");

    }
    public void QuiGame()
    {

        Debug.Log("Quite Game !!!");
        Application.Quit();

    }
    public void Retour()
    {

        ReglagesMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);

    }
    public void reglages()
    {

        ReglagesMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);

    }

}
