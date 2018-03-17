using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip CoinGained;
    public AudioClip CoinSpent;
    public AudioClip[] Hits;

    public void PlayCoinGained()
    {
        var audioSource = GetComponent<AudioObjectPool>().GetAudioSource();
        audioSource.clip = CoinGained;
        audioSource.Play();
    }
    public void PlayCoinSpent()
    {
        var audioSource = GetComponent<AudioObjectPool>().GetAudioSource();
        audioSource.clip = CoinSpent;
        audioSource.Play();
    }
    public void PlayHit()
    {
        var audioSource = GetComponent<AudioObjectPool>().GetAudioSource();
        audioSource.clip = Hits[Random.Range(0, Hits.Length)];
        audioSource.Play();
    }
}
