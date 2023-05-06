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
        mixer.SetFloat("MasterVolume", GlobalManager.Master);
        mixer.SetFloat("SFXVolume", GlobalManager.SFX);
        mixer.SetFloat("MusicVolume", GlobalManager.Music);
        SetSliders();
    }

    public void UpdateMasterVolume()
    {
        mixer.SetFloat("MasterVolume", GlobalManager.Master);
        GlobalManager.Master = masterSlider.value;
        SaveSystem.SavePlayer();
    }
    // called when we update the sfx slider
    public void UpdateSFXVolume()
    {
        mixer.SetFloat("SFXVolume", GlobalManager.SFX);
        GlobalManager.SFX = sfxSlider.value;
        SaveSystem.SavePlayer();
    }
    // called when we update the music slider
    public void UpdateMusicVolume()
    {
        mixer.SetFloat("MusicVolume", GlobalManager.Music);
        GlobalManager.Music = musicSlider.value;
        SaveSystem.SavePlayer();
    }

    void Update()
    {

    }
}