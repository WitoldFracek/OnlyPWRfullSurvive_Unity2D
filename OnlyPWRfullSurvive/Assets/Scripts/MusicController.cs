using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;
    [SerializeField] AudioClip audioClip;

    private float lastSavedVolume;
    private bool lastSavedMusicState;

    public static MusicController musicController;


    private void Awake()
    {
        if (musicController == null)
        {
            DontDestroyOnLoad(gameObject);
            musicController = this;
            slider.value = audioSource.volume;
        }
        else if (musicController != this)
        {
            musicController.slider = this.slider;
            musicController.slider.onValueChanged.AddListener(musicController.OnSliderChange);
            musicController.slider.value = musicController.lastSavedVolume;

            musicController.toggle = this.toggle;
            musicController.toggle.onValueChanged.AddListener(musicController.OnCheckBoxChanged);
            musicController.toggle.isOn = musicController.lastSavedMusicState;

            Destroy(gameObject);
        }
        var musicPlayers = GameObject.FindGameObjectsWithTag("Music");
        if (musicPlayers.Length > 1)
        {
            Destroy(gameObject);
        }
        lastSavedVolume = slider.value;
        lastSavedMusicState = toggle.isOn;
    }

    public void OnSliderChange(float volume)
    {
        audioSource.volume = volume;
        lastSavedVolume = volume;
    }

    public void OnCheckBoxChanged(bool state)
    {
        if (state)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        lastSavedMusicState = state;
    }
}
