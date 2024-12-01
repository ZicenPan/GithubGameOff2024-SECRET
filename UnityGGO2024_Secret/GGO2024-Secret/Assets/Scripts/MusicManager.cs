using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource introSource;
    public AudioSource loopSource;

    void Start()
    {
        // Play the intro clip
        introSource.Play();

        // Schedule the loop clip to start when the intro clip finishes
        loopSource.PlayScheduled(AudioSettings.dspTime + introSource.clip.length);
    }
}