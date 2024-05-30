using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFW_FTM_Spawn : MonoBehaviour
{
    public ParticleSystem spawn;

    public void spawnVFX()
    {
        spawn.Play();

    }
}
