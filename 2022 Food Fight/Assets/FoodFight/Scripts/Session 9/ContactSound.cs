using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactSound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //avoid playing hit sound when all physic object settle at the load of the level.
        if (Time.timeSinceLevelLoad < 1.0f)
        {
            return;
        }

        AudioClip randomClip = clips[Random.Range(0, clips.Length)];

        audioSource.PlayOneShot(randomClip);

    }
}
