using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
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
        sources[1].pitch = 1.0f / rb.mass;

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
        print("player collision " + collision.collider.name);
 
        Rigidbody  rbOther = collision.gameObject.GetComponent<Rigidbody>();
        if(rbOther) {
            if(rb.mass > rbOther.mass){
                print("we collided with a lighter object");
                sources[1].Play();
            } else {
                print("we collided with a heavier object");

            }
        }else {
            print("we collided with an object without MASS !! ");
            sources[1].Play();
        }
        
    }
}
