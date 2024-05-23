using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBackToNormal : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera Activ_Cam;
    void OnTriggerEnter2D(Collider2D other)
    {
        //Passiv_Cam.Priority = 1;
        Activ_Cam.m_Lens.OrthographicSize = 6.81f;

    }
}
