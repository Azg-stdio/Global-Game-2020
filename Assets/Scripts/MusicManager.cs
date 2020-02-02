using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] audios;
    AudioSource source;
    void Start()
    {
        source= GetComponent<AudioSource>();
    }

    public void PlaySFX(int sound)
    {
        source.clip = audios[sound];
        source.Play();
    }

    public void StopSFX()
    {
        source.Stop();
    }
}
