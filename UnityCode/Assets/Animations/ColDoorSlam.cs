using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDoorSlam : MonoBehaviour
{
    public  static bool door4Open = false;
    public GameObject door;
    public GameObject doorlamp;
    public GameObject corridorlamp;
    public GameObject turnOffLamp1;
    public GameObject turnOffLamp2;
    public AudioSource doorSlam;
    public AudioSource jumpscare;
    bool havePlayedJS = false;


    Animator anim;
    bool TRIGGERED = false;


    void Start()
    {
        anim = door.GetComponent<Animator>();
        doorSlam = door.GetComponent<AudioSource>();
        jumpscare = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!havePlayedJS)
        {
            
            jumpscare.PlayDelayed(0.5f);
            havePlayedJS = true;
        }

        if (!TRIGGERED){
            anim.SetTrigger("doorSlam");
            StartCoroutine(waiter());
            turnOffLamp2.GetComponent<LightController>().lightSwitch();
            turnOffLamp1.GetComponent<LightController>().lightSwitch();
           // doorSlam.PlayDelayed(0.4f);
            door4Open = true;


        }
        TRIGGERED = true;
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        doorlamp.GetComponent<LightController>().lightSwitch();
        corridorlamp.GetComponent<LightController>().flicker = true;
    }
}
