using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDoorClose : MonoBehaviour
{
    public GameObject door;
    Animator anim;
    public AudioSource knirk;
    bool knirkHavePlayed = false;

    void Start(){
        anim = door.GetComponent<Animator>();
        knirk = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other){
        anim.SetTrigger("doorClose");


        if (!knirkHavePlayed)
        {
            knirk.Play();
            knirkHavePlayed = true;
        }
    }
}
