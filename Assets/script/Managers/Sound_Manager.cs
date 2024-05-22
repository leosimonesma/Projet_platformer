using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager instance;
    [SerializeField] private AudioSource SoundFXObject;


    private void Awake()
    {
        if (instance == null)
        {

            instance = this;

        }
    }


    public void playSoundDXClip(AudioClip audioclip, Transform SpawnTransform, float Volume)
    {
        AudioSource audioSource = Instantiate(SoundFXObject, SpawnTransform.position, Quaternion.identity);

        audioSource.clip = audioclip;
        audioSource.volume = Volume;
        audioSource.Play();
        float ClipLenght = audioSource.clip.length;
        Destroy(audioSource.gameObject, ClipLenght );

    }
    public void playSoundRandomDXClip(AudioClip[] audioclip, Transform SpawnTransform, float Volume)
    {
        AudioSource audioSource = Instantiate(SoundFXObject, SpawnTransform.position, Quaternion.identity);


        int rand = Random.Range(0, audioclip.Length);
        audioSource.clip = audioclip[rand];
        audioSource.volume = Volume;
        audioSource.Play();
        float ClipLenght = audioSource.clip.length;
        Destroy(audioSource.gameObject, ClipLenght);

    }





}
