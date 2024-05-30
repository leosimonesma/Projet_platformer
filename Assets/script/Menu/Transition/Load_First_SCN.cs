using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_First_SCN : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("SCN_Niveau1");
    }
}
