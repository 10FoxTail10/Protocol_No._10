using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMusic : MonoBehaviour
{
    [Header("Glabal volume")]
    [SerializeField] public Toggle toggleGVolume;
    [SerializeField] public Slider sliderGVolume;
    private float _globalVolume = 1f;

    [Header("Volume music")]
    [SerializeField] public Toggle toggleVMusic;
    [SerializeField] public Slider sliderVMusic;
    private float _volumeMusic = 1f;
    
    [Header("Volume of sounds")]
    [SerializeField] public Toggle toggleVSound;
    [SerializeField] public Slider sliderVSound;
    private float _volumeSound = 1f;

    [Header("Audio sourse")]
    [SerializeField] public AudioSource audioMusic;
    [SerializeField] public List<AudioSource> audioSound;

    void Start()
    {
        Load();
        InvokeRepeating("ValueMusic", 0f, 0f);
    }

    public void SliderMusic()
    {
        _globalVolume = sliderGVolume.value;

        _volumeMusic = _globalVolume * sliderVMusic.value;

        _volumeSound = _globalVolume * sliderVSound.value;

        Save();
        ValueMusic();
    }

    public void ToggleMusic()
    {
        if (toggleGVolume.isOn == true)
        {
            _globalVolume = sliderGVolume.value;
            _volumeMusic = _globalVolume * sliderVMusic.value;
            _volumeSound = _globalVolume * sliderVSound.value;
        }
        else
        {
            _globalVolume = 0;
        }

        if (toggleVMusic.isOn == true && toggleGVolume.isOn == true)
        {
            _volumeMusic = sliderVMusic.value;
        }
        else
        {
            _volumeMusic = 0;
        }

        if (toggleVSound.isOn == true && toggleGVolume.isOn == true)
        {
            _volumeSound = sliderVSound.value;
        }
        else
        {
            _volumeSound = 0;
        }

        Save();
        ValueMusic();
    }

    private void ValueMusic()
    {
        audioMusic.volume = _volumeMusic;
        for (int i = 0; i < audioSound.Count; i++)
        {
            audioSound[i].volume = _volumeSound;
        }

        if (_globalVolume == 0) { toggleGVolume.isOn = false; } else { toggleGVolume.isOn = true; }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Global Volume", _globalVolume);
        PlayerPrefs.SetFloat("Volume Music", _volumeMusic);
        PlayerPrefs.SetFloat("Volume of sounds", _volumeSound);
    }

    private void Load()
    {
        _globalVolume = PlayerPrefs.GetFloat("Global Volume", _globalVolume);
        _volumeMusic = PlayerPrefs.GetFloat("Volume Music", _volumeMusic);
        _volumeSound = PlayerPrefs.GetFloat("Volume of sounds", _volumeSound);
    }
}
