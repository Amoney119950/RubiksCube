using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomSoundLooper : MonoBehaviour
{
    public AudioClip[] soundClips; // Assign your 5 sounds in the inspector
    private AudioSource audioSource;
    private List<AudioClip> clipPool;

    private void Start()
    { 
        clipPool = new List<AudioClip>(soundClips);
        audioSource = GetComponent<AudioSource>();

        if (soundClips.Length == 0)
        {
            Debug.LogWarning("No audio clips assigned!");
            return;
        }
       
        StartCoroutine(PlayRandomSounds());
    }

    private System.Collections.IEnumerator PlayRandomSounds()
    {
        while (true) // Infinite loop for continuous playback
        {
            if (clipPool.Count == 0) clipPool.AddRange(soundClips);
            int randomIndex = Random.Range(0, clipPool.Count);
            AudioClip clip = clipPool[randomIndex];
            clipPool.RemoveAt(randomIndex);
            audioSource.clip = clip;
            audioSource.Play();

            // Wait until the current clip finishes before playing the next
            yield return new WaitForSeconds(clip.length);
        }
    }
}
