using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeAdjustment : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private AudioSource audioSource;
    void Start()
    {

        volumeSlider = GetComponent<Slider>();
        volumeSlider.maxValue = 1;
        volumeSlider.minValue = 0;
        PlayerPrefs.GetFloat("VolumeLevel");
        
        
    }

   
    void Update()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeLevel", volumeSlider.value);
    }
}
