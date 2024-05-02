using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;// permet de savoir si le jeu est en pause il peut être utilisé dans d'autres scripts
    public GameObject PauseMenuUI;
    public GameObject ReglagesMenuUI;
    public Player_Mouvements stopmouvements;

    // si on appuie sur echappe quand le bool GameIsPaused est vrais alors le jeu continue et on sort du menu pause sinon on met le jeu en pause et affiche le menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }

        }
    }
    // fonction pour relancer le jeu depuis le menu pause et désaficher le menu
    public void Resume()
    {
        stopmouvements.playMouvement();
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ReglagesMenuUI.SetActive(false);
    }
    // fonction pour mettre en pause et afficher le menu
    void Pause()
    {
        stopmouvements.stopMouvement();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SCN_Main_Menu");
        Debug.Log("Main  Menu!!!");
    }

    public void QuiGame()
    {

        Debug.Log("Quite Game !!!");
        Application.Quit();

    }
    public void reglages()
    {

        ReglagesMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);

    }
    public void reglagesquit()
    {

        ReglagesMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);

    }
}
