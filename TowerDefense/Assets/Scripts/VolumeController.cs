using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    [SerializeField] private AudioSource Music;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeTextUI;


    private void Start()
    {
        LoadMusicValues();
    }

    public void SetMusicVolume(float volume)//Sets the numbers near the sliders to volume value.
    {
        Music.volume = volume;
        volumeTextUI.text = volume.ToString("0.0");
    }

    private void LoadMusicValues()//loads the volume according to value.
    {
        float MusicValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = MusicValue;
        Music.volume = MusicValue;
    }
 
    public void SaveVolume()//Button saves the value into a playerprefs.
    {
        float MusicValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", MusicValue);
        LoadMusicValues();//When saved the value is loaded and the volume is adjusted.
    }

   

}
