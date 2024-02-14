using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    public AudioClip[] bgmClips;

    public void PlayBGM(string _scene)
    {
        int index = 0;

        switch (_scene)
        {
            //TODO: SceneTitle input
            case "StageScene": index = 0; break;
        }

        bgmPlayer.clip = bgmClips[index];
        bgmPlayer.Play();
    }

    public void PlaySFX(AudioClip _clip)
    {
        sfxPlayer.PlayOneShot(_clip);
    }
}
