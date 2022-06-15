using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip uiButton, pass, playerActive, playerDisactive, win, lose;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void AudioPlay(string name)
    {
        switch (name)
        {
            case "UI": audioSource.clip = uiButton;break;
            case "Pass": audioSource.clip = pass; break;
            case "PlayerActive": audioSource.clip = playerActive; break;
            case "PlayerDisactive": audioSource.clip = playerDisactive; break;
            case "Win": audioSource.clip = win; break;
            case "Lose": audioSource.clip = lose; break;
        }
        if(audioSource.clip)
        audioSource.Play();
    }
}
