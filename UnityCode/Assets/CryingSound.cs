using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingSound : MonoBehaviour
{
    
    public GameObject door;
    public AudioSource crying;

    // Start is called before the first frame update
    void Start()
    {
        crying = door.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        crying.Play();


    }
}
