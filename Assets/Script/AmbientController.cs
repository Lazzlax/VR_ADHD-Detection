using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientController : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> clips;

    public float timeBetween;
    public float minTimeBetween;
    public float maxTimeBetween;

    void Update() {
        timeBetween -= Time.deltaTime;
    }

    void LateUpdate() {
        if (!audioSource.isPlaying && timeBetween <= 0) {
            audioSource.clip = clips[Random.Range(0, clips.Count)];
            timeBetween = Random.Range(minTimeBetween, maxTimeBetween);
            audioSource.Play();
        }
    }

}
