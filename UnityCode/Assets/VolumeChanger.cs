using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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