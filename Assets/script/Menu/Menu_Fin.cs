using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu_Fin : MonoBehaviour
{

    
    void Update()
    {
        if (Input.GetButtonDown("DialogueCustom"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("SCN_Main_Menu");
        }
    }
}
