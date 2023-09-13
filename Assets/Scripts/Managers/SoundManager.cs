using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static SoundManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public AudioSource BgmAudioSource;
    public AudioSource MainAudioSource;
    public AudioSource BlockBrokenAudioSource;
    public AudioSource BallBounceAudioSource;

    public AudioClip BgmAudioClip;
    public AudioClip MainAudioClip;
    public AudioClip BlockBrokenAudioClip;
    public AudioClip BallBounceClip;


    public void PlayBgmSound()
    {
        BgmAudioSource.clip = BgmAudioClip;
        BgmAudioSource.Play();
    }

    public void MainBgmSound()
    {
        BgmAudioSource.Stop();
        MainAudioSource.clip = MainAudioClip;
        MainAudioSource.Play();
    }

    public void BlockBrokenSound()
    {
        BlockBrokenAudioSource.clip = BlockBrokenAudioClip;
        BlockBrokenAudioSource.PlayOneShot(BlockBrokenAudioClip);
    }

    public void BallBounceSound()
    {
        BallBounceAudioSource.clip = BallBounceClip;
        BallBounceAudioSource.PlayOneShot(BallBounceClip);
    }


    private void audioSourcePlay()
    {
        //audioSource.Play();
        //BgmSound ¸ØÃß´Â¹ý?
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
