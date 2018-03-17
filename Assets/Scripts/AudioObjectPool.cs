using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObjectPool : MonoBehaviour
{
    public List<GameObject> Audios;

    private void Start()
    {
        var ag = new GameObject();
        ag.name = "SoundEffect(0)";
        ag.AddComponent<AudioSource>();
        ag.transform.SetParent(transform);
        Audios.Add(ag);
    }

    public AudioSource GetAudioSource()
    {
        foreach (var go in Audios)
        {
            if (!go.GetComponent<AudioSource>().isPlaying)
            {
                return go.GetComponent<AudioSource>();
            }
        }

        // no idle audio source found, create new one
        var ag = new GameObject();
        ag.name = "SoundEffect(" + Audios.Count + ")";
        ag.AddComponent<AudioSource>();
        ag.transform.SetParent(transform);
        Audios.Add(ag);
        return ag.GetComponent<AudioSource>();
    }
}