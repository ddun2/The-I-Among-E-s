using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;
    // 상황별로 재생할 사운드 배열
    public AudioClip[] sfxClips;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;

        bgmPlayer = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
        sfxPlayer = GameObject.Find("SFXPlayer").GetComponent<AudioSource>();
    }

    public void PlaySound(string type)
    {
        // TODO:: type 받아서 맞는 사운드 재생하도록 처리
        // switch-case?

        //sfxPlayer.clip = sfxClips[0];
        //sfxPlayer.Play();
    }
}
