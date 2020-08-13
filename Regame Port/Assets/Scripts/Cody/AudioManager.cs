using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

    public void PlayAudio(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
        StartCoroutine(WaitForAudio(audioSource.clip));
    }

    private IEnumerator WaitForAudio(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
    }
}
