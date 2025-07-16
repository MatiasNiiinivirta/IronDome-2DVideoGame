using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;
    void Start()
    {
        //Starts the tune
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            Load();
            
        }

        else
        {
            volumeSlider.value = 1;
            Load();
        }
        
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
