using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingSound : MonoBehaviour
{
    
    public GameObject door;
    public AudioSource crying;
    bool isCrying = false;

    // Start is called before the first frame update
    void Start()
    {
        crying = door.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!isCrying) {
            crying.Play();
            isCrying = true;
        }

    }
}
