using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightpushpull : MonoBehaviour
{
    [SerializeField] pushetpull player;
    [SerializeField] Light2D GrabZone;


    public void Update()
    {
        setLightOn();
        setLightOff();

    }

    public void setLightOn()
    {
        if (player.isGrabbing == true)
        {
            GrabZone.intensity = 10;
        }
    }
    public void setLightOff()
    {
        if (player.isGrabbing == false)
        {
            GrabZone.intensity = 0;
        }
    }

}
