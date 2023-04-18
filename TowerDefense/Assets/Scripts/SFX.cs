using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SFX : MonoBehaviour
{
    [SerializeField] public Slider SFXSlider;
    [SerializeField] private AudioSource[] SFXSounds;
    [SerializeField] private TextMeshProUGUI SFXTextUI;
    [SerializeField] private AudioSource SFXTest;


    private void Start()
    {
        LoadSFXVolume();
    }


    public void SetSFXVolume(float volume)//Sets the numbers near the sliders to volume value.
    {
        foreach(var sound in SFXSounds) 
        {
            sound.volume = volume;
        }
        SFXTextUI.text = volume.ToString("0.0");

    }

    public void LoadSFXVolume()//loads the volume according to value.
    {
        float SFXValue = PlayerPrefs.GetFloat("SFX");
        SFXSlider.value = SFXValue;

        foreach(var sound in SFXSounds)
        {
            sound.volume = SFXValue;
        }
    }

    public void SaveSFXVolume()//Button saves the value into a playerprefs.
    {
        float SFXValue = SFXSlider.value;
        PlayerPrefs.SetFloat("SFX", SFXValue);
        LoadSFXVolume();//When saved the value is loaded and the volume is adjusted.
    }

    public void PlaySound()//This is for player to test the sound effect volume in menu. Ignore in main levels.
    {
        SFXTest.volume= SFXSlider.value;
        SFXTest.Play();
    }
}
