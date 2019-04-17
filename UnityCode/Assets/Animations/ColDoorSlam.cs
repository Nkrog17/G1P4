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
    Animator anim;


    void Start()
    {
        anim = door.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("doorSlam");
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        doorlamp.GetComponent<LightController>().lightSwitch();
        corridorlamp.GetComponent<LightController>().flicker = true;
        turnOffLamp2.GetComponent<LightController>().lightSwitch();
        turnOffLamp1.GetComponent<LightController>().lightSwitch();
    }
}
