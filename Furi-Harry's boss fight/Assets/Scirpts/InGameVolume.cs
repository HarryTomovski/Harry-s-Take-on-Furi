using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameVolume : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    void Start()
    {
        audioSource.GetComponent<AudioSource>();
        float volume = PlayerPrefs.GetFloat("VolumeLevel");
        audioSource.volume = volume;
    }

    
}
