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
        instance = this;
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
            //TODO: SceneTitle input
            case "StartScene": index = 0; break;
            case "StageScene": index = 1; break;
        }

        bgmPlayer.clip = bgmClips[index];
        bgmPlayer.Play();
    }

    public void PlaySFX(AudioClip _clip)
    {
        sfxPlayer.PlayOneShot(_clip);
    }
}
