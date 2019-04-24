using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDoorPound : MonoBehaviour
{
    public GameObject door;
    Animator anim;
    public AudioSource pounding;
    bool poundingHavePlayed; 

    void Start(){
        pounding = door.GetComponent<AudioSource>();
        anim = door.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other){
        anim.SetTrigger("doorPound");

        if (!poundingHavePlayed)
        {
            pounding.PlayDelayed(0.35f);
            poundingHavePlayed = true;
        }
    }
}
