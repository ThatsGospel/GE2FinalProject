using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQueue : MonoBehaviour
{
    private AudioSource src;
    public AudioClip[] clips;
    private int currentClip = 0;

    public void Start()
    {
        src = GetComponent<AudioSource>();
        src.clip = clips[currentClip];
        src.Play();
    }

    public void Update()
    {
        if (!src.isPlaying)
        {
            currentClip++;
            src.clip = clips[currentClip];
            src.Play();
        }

    }
}
