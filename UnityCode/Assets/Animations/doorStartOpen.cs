using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class doorStartOpen : MonoBehaviour
{
    public GameObject doorSound;
    public GameObject dooranim;
    Animator anim;
    public AudioSource knirk;
    bool knirkxd = false;

    void Start()
    {
        knirk = doorSound.GetComponent<AudioSource>();
        anim = dooranim.GetComponent<Animator>();
    }

    void Update()
    {
        if (SerialPortScript.baseLine == false)
        {
            anim.SetTrigger("doorStartOpen");
            if (!knirkxd)
            {
                
                knirk.PlayDelayed(0.4f);
                knirkxd = true;
            }
        }


    }
}
