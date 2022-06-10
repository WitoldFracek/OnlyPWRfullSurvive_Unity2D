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
    [SerializeField] List<AudioClip> audioClips;

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
            musicController.slider.value = lastSavedVolume;

            musicController.toggle = this.toggle;
            musicController.toggle.onValueChanged.AddListener(musicController.OnCheckBoxChanged);
            musicController.toggle.isOn = lastSavedMusicState;

            Destroy(gameObject);
        }
        var musicPlayers = GameObject.FindGameObjectsWithTag("Music");
        if (musicPlayers.Length > 1)
        {
            Destroy(gameObject);
        }
        lastSavedVolume = slider.value;
        lastSavedMusicState = toggle.isOn;
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomAudioClip();
            audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        if (!audioSource.isPlaying && lastSavedMusicState)
        {
            audioSource.clip = GetRandomAudioClip();
            audioSource.Play();
        }
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

    private AudioClip GetRandomAudioClip()
    {
        var rnd = new System.Random();
        int index = rnd.Next(0, audioClips.Count);
        return audioClips[index];
    }
}
