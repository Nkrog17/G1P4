using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDoorClose : MonoBehaviour
{
    public GameObject door;
    Animator anim;
    public AudioSource close;
    bool knirkHavePlayed = false;

    void Start(){
        anim = door.GetComponent<Animator>();
        close = door.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other){
      
        if (!knirkHavePlayed)
        {
            anim.SetTrigger("doorClose");

            close.PlayDelayed(0.5f);
            knirkHavePlayed = true;
        }
    }
}
