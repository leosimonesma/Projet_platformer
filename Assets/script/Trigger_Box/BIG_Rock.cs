using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIG_Rock : MonoBehaviour
{
    [SerializeField] private Transform monster1;
    [SerializeField] private Transform monster2;
    [SerializeField] private Transform rock;
    [SerializeField] Animator Animator_rock;
    void Update()
    {

        if (monster1 == null&& monster2 == null)
        {
            Animator_rock.SetTrigger("TiggerDown");

        }
        
    }
}
