using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{

    public AudioSource jumpscare;
    bool havePlayed = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (!havePlayed)
        {
            jumpscare = GetComponent<AudioSource>();
            jumpscare.Play();
            havePlayed = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
