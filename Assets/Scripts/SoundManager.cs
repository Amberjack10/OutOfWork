using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    public AudioClip[] bgmClips;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        PlayBGM("StartScene");
    }

    public void PlayBGM(string _scene)
    {
        int index = 0;

        switch (_scene)
        {
            case "StartScene": index = 0; break;
            case "SSH_Stage": index = 1; break;
            default: index = 0; break;
        }

        if(bgmPlayer != null)
        {
            bgmPlayer.clip = bgmClips[index];
            bgmPlayer.Play();
        }
    }

    public void PlaySFX(AudioClip _clip)
    {
        sfxPlayer.PlayOneShot(_clip);
    }
}
