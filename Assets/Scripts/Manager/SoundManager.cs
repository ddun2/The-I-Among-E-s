using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;
    // ��Ȳ���� ����� ���� �迭
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
        // TODO:: type �޾Ƽ� �´� ���� ����ϵ��� ó��
        // switch-case?

        //sfxPlayer.clip = sfxClips[0];
        //sfxPlayer.Play();
    }
}
