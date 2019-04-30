using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorClose2 : MonoBehaviour
{
    public GameObject door;
    Animator anim;
    public AudioSource knirk;
    bool knirkHavePlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        knirk = door.GetComponent<AudioSource>();
        anim = door.GetComponent<Animator>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (ColDoorSlam.door4Open == true)
        {
            anim.SetTrigger("doorClose2");

            if (!knirkHavePlayed)
            {
                knirk.PlayDelayed(0.4f);
                knirkHavePlayed = true;
            }
        }
    }
}
