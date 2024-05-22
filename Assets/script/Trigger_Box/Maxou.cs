using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maxou : MonoBehaviour
{
    [SerializeField] private AudioClip[] SwingSounds;
    private Transform PlayerTransform;
    private const float interactDistance = 10f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Vector2.Distance(PlayerTransform.position, transform.position) < interactDistance)
        {
            Sound_Manager.instance.playSoundRandomDXClip(SwingSounds, transform, 0.2f);
        }
    }
    private void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
}
