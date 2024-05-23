using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeFromMaxou : MonoBehaviour
{
    private Transform PlayerTransform;
    [SerializeField] private MortEtRespawn rezP;
    private void Awake()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTransform.position = rezP.Respawn;
    }
}
