using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class doorStartOpen : MonoBehaviour
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

    void Update()
    {
        if (SerialPortScript.baseLine == false)
        {
            if (!knirkHavePlayed)
            {
                anim.SetTrigger("doorStartOpen");
                knirk.PlayDelayed(0.4f);
                knirkHavePlayed = true;
            }
        }


    }
}
