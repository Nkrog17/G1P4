using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColDoorOpen : MonoBehaviour
{
    public GameObject door;
    Animator anim;
    public AudioSource knirk;
    bool knirkHavePlayed = false;

    void Start()
    {
        knirk = door.GetComponent<AudioSource>();
        anim = door.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (ColDoorSlam.door4Open == true) {
            

            if (!knirkHavePlayed)
            {
                anim.SetTrigger("doorOpen");
                knirk.PlayDelayed(0.4f);
                knirkHavePlayed = true;
                
            }
        }

        
    }
}
