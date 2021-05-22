using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudioController : MonoBehaviour
{

    AudioSource sources;
    Renderer rend;  
    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        sources.pitch = 1.73f / rend.bounds.size.magnitude;
        //print("BoxSice: " + rend.bounds.size.magnitude);
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {
        print("box colission " + collision.collider.name);
        sources.Play();
    }
}
