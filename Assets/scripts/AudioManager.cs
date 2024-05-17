using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioManager audioManager;
    [Header("-------------Audio Source-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------------Audio Clip-------------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip jumppad;
    public AudioClip jump;
    public AudioClip tongueout;
    public GameObject DeadScreen;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        musicSource.loop = true;


    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    void Update()
    {
        // Check if the first object is set active
        if (DeadScreen.activeSelf)
        {
            musicSource.clip = background;
            musicSource.Pause();
        }

    }
}
