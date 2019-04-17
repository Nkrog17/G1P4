using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDoorPound : MonoBehaviour
{
    public GameObject door;
    Animator anim;
    public AudioSource knirk;
    bool knirkHavePlayed; 

    void Start(){
        knirk = GetComponent<AudioSource>();
        anim = door.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other){
        anim.SetTrigger("doorPound");

        if (!knirkHavePlayed)
        {
            knirk.Play();
            knirkHavePlayed = true;
        }
    }
}
