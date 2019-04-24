using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioData;

    void OnEnable()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}
    