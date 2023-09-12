using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //private static SoundManager _instance;

    public AudioSource BgmAudioSource;
    public AudioSource EffectAudioSource;

    public AudioClip BgmAudioClip;
    public AudioClip effectAudioClip;

    private bool isPlaying = false;

    public void Start()
    {
        BgmAudioSource.clip = BgmAudioClip;
        BgmAudioSource.Play();
        //배열 관리 후 여러개의 음악 넣기
    }

    public void PlayEffectSound()
    {
        EffectAudioSource.clip = effectAudioClip;
        //EffectAudioSource.
        //배열관리하는법?
    }

    private void audioSourcePlay()
    {
        //audioSource.Play();
        //BgmSound 멈추는법?
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
