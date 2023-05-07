using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    public AudioMixer mixer;
   public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    // called at the start of the game
    // set the slider values to be the saved volume settings
    void SetSliders()
    {
        masterSlider.value = GlobalManager.Master;
        sfxSlider.value = GlobalManager.SFX;
        musicSlider.value = GlobalManager.Music;
    }
    
    void Start()
    {
        mixer.SetFloat("Master", GlobalManager.Master);
        mixer.SetFloat("SFX", GlobalManager.SFX);
        mixer.SetFloat("Music", GlobalManager.Music);
        SetSliders();
    }

    public void UpdateMasterVolume()
    {
        GlobalManager.Master = masterSlider.value;
        mixer.SetFloat("Master", GlobalManager.Master);
        SaveSystem.SavePlayer();
    }
    // called when we update the sfx slider
    public void UpdateSFXVolume()
    {
        GlobalManager.SFX = sfxSlider.value;
        mixer.SetFloat("SFX", GlobalManager.SFX);
        SaveSystem.SavePlayer();
    }
    // called when we update the music slider
    public void UpdateMusicVolume()
    {
        GlobalManager.Music = musicSlider.value;
        mixer.SetFloat("Music", GlobalManager.Music);
        SaveSystem.SavePlayer();
    }

    void Update()
    {

    }
}