using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource SoundEffect;
    public AudioClip CoinGained;
    public AudioClip CoinSpent;
    public AudioClip[] Hits;

    public void PlayCoinGained()
    {
        SoundEffect.clip = CoinGained;
        SoundEffect.Play();
    }
    public void PlayCoinSpent()
    {
        SoundEffect.clip = CoinSpent;
        SoundEffect.Play();
    }
    public void PlayHit()
    {
        SoundEffect.clip = Hits[Random.Range(0, Hits.Length)];
        SoundEffect.Play();
    }
}
