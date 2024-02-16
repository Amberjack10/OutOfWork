using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    private void Start()
    {
        SetVolume();
    }

    public void VolumeControl(string _type)
    {
        Slider slider;

        switch(_type)
        {
            case "Master":
                slider = masterSlider;
                break;
            case "BGM":
                slider = bgmSlider;
                break;
            case "SFX":
                slider = sfxSlider;
                break;
            default:
                slider = masterSlider;
                break;
        }
        
        float volume = slider.value;

        if (volume == -40f) audioMixer.SetFloat(_type, -80);
        else audioMixer.SetFloat(_type, volume);
    }

    void SetVolume()
    {
        audioMixer.GetFloat("Master",out float masterVolume);
        masterSlider.value = masterVolume;
        audioMixer.GetFloat("BGM", out float bgmVolume);
        bgmSlider.value = bgmVolume;
        audioMixer.GetFloat("SFX", out float sfxVolume);
        sfxSlider.value = sfxVolume;
    }
}
