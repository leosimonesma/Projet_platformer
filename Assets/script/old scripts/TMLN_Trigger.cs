using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class TMLN_Trigger : MonoBehaviour
{



    
    [SerializeField] PlayableDirector cinematique;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cinematique.Play();
       
    }


}
