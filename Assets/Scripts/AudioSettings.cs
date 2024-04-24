using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer audioMixer;
    private float SavedMasterVolume;

    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume"));
    }
    public void SetVolume(float volume)
    {
        if (volume < 1)
        {
            volume = .001f;
        }
        SliderChange(volume);
        PlayerPrefs.SetFloat("SavedMasterVolume", volume);
        audioMixer.SetFloat("MasterVolumeSetting", Mathf.Log10(volume / 100) * 20);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void SliderChange(float volume)
    {
        soundSlider.value = volume;
    }

}
