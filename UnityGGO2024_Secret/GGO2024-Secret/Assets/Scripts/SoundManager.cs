using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    MOM,
    EAT
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private bool isPlaying = true;

    private void Awake()
    {
        instance = this;
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlaying) {

        }
    }
}
