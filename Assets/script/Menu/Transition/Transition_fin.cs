using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition_fin : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("SCN_Niveau4");
    }
}
