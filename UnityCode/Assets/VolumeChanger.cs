using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script sets the volume on all audio to something lower than 1.
public class VolumeChanger : MonoBehaviour
{
    public float volume;

    void Start()
    {
        var foundObjects = FindObjectsOfType<AudioSource>();
        foreach(AudioSource i in foundObjects){
            i.volume = volume;
        }
    }
}