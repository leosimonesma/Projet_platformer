using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public GameObject ReglagesMenuUI;
    public GameObject MainMenuUI;
    [SerializeField] GameObject MenuFirstButton, OptionFirstButton, OptionCloseButton;
    [SerializeField] Animator Animator_Transition;
    public void ButtonPlay()
    {
        
        SceneManager.LoadScene("SCN_Intro");

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
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OptionCloseButton);

    }
    public void Transition()
    {

        Animator_Transition.SetTrigger("Transition_Trigger");
    }
    public void reglages()
    {

        ReglagesMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OptionFirstButton);

    }
    public void FullScreen()
    {
        Screen.fullScreen=!Screen.fullScreen;

    }

}
