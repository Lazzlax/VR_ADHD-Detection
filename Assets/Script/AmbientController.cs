using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientController : MonoBehaviour
{
    public AudioSource audioSource; // A representation of audio sources in 3D. 
    public List<AudioClip> clips;   // List of AudioClips for contain the audio.

    public float timeBetween;       // Current delay between each audio.
    public float minTimeBetween;    // Minimal delay between each audio.
    public float maxTimeBetween;    // Maximum delay between each audio.

    /// <summary>
    /// Reduced the value of timeBetween
    /// </summary>
    void Update() {
        timeBetween -= Time.deltaTime;
    }

    /// <summary>
    /// Playing the audio when the audioSource is not playing and the current delay is equal or less than 0. 
    /// </summary>
    void LateUpdate() {
        if (!audioSource.isPlaying && timeBetween <= 0) {
            audioSource.clip = clips[Random.Range(0, clips.Count)];
            timeBetween = Random.Range(minTimeBetween, maxTimeBetween);
            audioSource.Play();
        }
    }

}
