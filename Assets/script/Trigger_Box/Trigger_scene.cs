using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trigger_scene : MonoBehaviour
{
    [SerializeField] Animator Animator_Transition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Animator_Transition.SetTrigger("Transition_Trigger_SNC_02");

        }
            
    }

}
