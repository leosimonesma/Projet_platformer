using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CameraSwitch : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera Activ_Cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void ShowOverheadView() {
    //    Passiv_Cam.enabled = false;
    //    Activ_Cam.enabled = true;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Passiv_Cam.Priority = 1;
        Activ_Cam.m_Lens.OrthographicSize = 11;

    }
    //void OnTriggerEnter2D(Collider2D other) 
    //{
    //    cam_01.SetActive(false);
    //    cam_02.SetActive(true);
    //}
}

