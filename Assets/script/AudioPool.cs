using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPool : MonoBehaviour
{
    [SerializeField] private GameObject audio;
    public List<AudioSource> audioPool = new List<AudioSource>();

    private void OnLevelWasLoaded(int level)
    {
        audioPool.Clear();
    }
    public AudioSource GetAvailableAudio(Vector3 pos)
    {

        foreach (AudioSource current in audioPool)
        {

            if (!current.isPlaying)
            {
                current.transform.position = pos;
                current.pitch = Random.Range(0.85f, 1.1f);
                return current;
            }
        }
        AudioSource newSource = Instantiate(audio).GetComponent<AudioSource>();
        newSource.volume = newSource.volume / 2;
        newSource.transform.position = pos;
        newSource.pitch = Random.Range(0.85f, 1.1f);
        audioPool.Add(newSource);
        return newSource;
    }
}
