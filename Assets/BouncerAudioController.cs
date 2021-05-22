using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerAudioController : MonoBehaviour
{
    AudioSource[] sources;
    Rigidbody rb;
    float speed = 0.0f;
    float weight = 0.0f;
    bool isPlaying = false;
    

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody>();
        weight = rb.mass;
        sources[1].pitch = 2.0f / rb.mass;

    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;

        if (speed > 0.1 && !isPlaying)  {
                isPlaying = true;
                sources[0].Play();
        }   else if (speed < 0.1 && isPlaying)
        {
             isPlaying = false;
            sources[0].Stop();
        }

        sources[0].pitch = speed / (weight * 2.0f);
        
    }

    void OnCollisionEnter(Collision collision) 
    {
        print("colission");
        sources[1].Play();
    }
}
