using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    [SerializeField] private AudioSource Music;
    [SerializeField] Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeTextUI;

    private void Start()
    {
        LoadMusicValues();
    }

    public void SetMusicVolume(float volume)//Text that shows at what value is the music currently at
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void LoadMusicValues()//Loads music values on start so it essentially works on every scene
    {
        float MusicValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = MusicValue;
        AudioListener.volume = MusicValue;
    }
 
    public void SaveVolume()//Saves values on press of button;
    {
        float MusicValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", MusicValue);
        LoadMusicValues();
    }

}
