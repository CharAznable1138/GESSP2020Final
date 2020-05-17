using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicPlayer;
    [SerializeField] AudioClip levelMusic;
    [SerializeField] AudioClip powerUpMusic;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        SetLevelMusic();
    }

    internal void SetLevelMusic()
    {
        musicPlayer.clip = levelMusic;
        musicPlayer.Play();
    }

    internal void SetPowerupMusic()
    {
        musicPlayer.clip = powerUpMusic;
        musicPlayer.Play();
    }

    internal void StopMusic()
    {
        musicPlayer.Stop();
    }
}
