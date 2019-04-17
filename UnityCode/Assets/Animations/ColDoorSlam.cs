using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDoorSlam : MonoBehaviour
{
    public GameObject door;
    public GameObject doorlamp;
    public GameObject corridorlamp;
    public GameObject turnOffLamp1;
    public GameObject turnOffLamp2;
    public AudioSource knirk;

    Animator anim;
    bool TRIGGERED = false;


    void Start()
    {
        knirk = GetComponent<AudioSource>();
        anim = door.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!TRIGGERED){
            anim.SetTrigger("doorSlam");
            StartCoroutine(waiter());
            turnOffLamp2.GetComponent<LightController>().lightSwitch();
            turnOffLamp1.GetComponent<LightController>().lightSwitch();
            knirk.Play();


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
