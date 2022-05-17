using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDrum : MonoBehaviour
{
    AudioSource drumAudio;
    // Start is called before the first frame update
    void Start()
    {
        drumAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        drumAudio.volume = other.relativeVelocity.magnitude;
        Debug.Log(drumAudio.volume);
        drumAudio.Play();
        
    }
    
}
