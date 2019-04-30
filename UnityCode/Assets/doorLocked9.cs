﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLocked9 : MonoBehaviour
{
    public GameObject door;
    public AudioSource lockedDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        lockedDoor = door.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (GoneGirl.door9IsClosed) {
            lockedDoor.Play();
        }

    }
}
