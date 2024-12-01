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
    private SoundType curIndex = SoundType.MOM;
    private float targetTime = 0;
    private float currentTime = 2;

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
        targetTime = 3;
    }

    public void setPlaying(bool playing)
    {
        this.isPlaying = playing; 
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (isPlaying && currentTime > targetTime) {
            PlaySound(curIndex);
            currentTime = 0;
        }
    }
}
