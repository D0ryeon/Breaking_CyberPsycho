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
        //�迭 ���� �� �������� ���� �ֱ�
    }

    public void PlayEffectSound()
    {
        EffectAudioSource.clip = effectAudioClip;
        //EffectAudioSource.
        //�迭�����ϴ¹�?
    }

    private void audioSourcePlay()
    {
        //audioSource.Play();
        //BgmSound ���ߴ¹�?
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
