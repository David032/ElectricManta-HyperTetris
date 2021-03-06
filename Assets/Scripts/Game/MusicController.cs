using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public List<AudioClip> Tracks = new List<AudioClip>();
    public AudioSource AudioPlayer;

    void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
        AudioPlayer.clip = Tracks[Random.Range(0, Tracks.Count)];
        AudioPlayer.Play();
    }

    void Update()
    {
        if (AudioPlayer.time == AudioPlayer.clip.length)
        {
            AudioPlayer.Stop();
            AudioPlayer.clip = Tracks[Random.Range(0, Tracks.Count)];
            AudioPlayer.Play();
        }
    }
}
