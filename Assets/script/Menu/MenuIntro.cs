using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIntro : MonoBehaviour
{
    [SerializeField] Animator Animator_Transition;
    void Update()
    {
        ButtonStartTransition();
    }

    public void ButtonStartTransition()
    {
        if (Input.GetButtonDown("DialogueCustom"))
        {
            Animator_Transition.SetTrigger("Transition_Trigger_SNC_01");
        }
    }
}
