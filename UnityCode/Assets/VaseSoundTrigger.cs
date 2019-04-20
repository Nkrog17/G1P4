﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSoundTrigger : MonoBehaviour
{
    public GameObject vaseNotBroken;
    public GameObject vaseBroken;

    public AudioSource vase;
    bool havePlayed = false;

    public GameObject Lamp1;
    public GameObject Lamp2;
    public GameObject Lamp3;
    public GameObject Lamp4;
    public GameObject Lamp5;
    public GameObject Lamp6;
    public GameObject Lamp7;

    public GameObject VaseLamp;

    private void OnTriggerEnter(Collider collider)
    {
        

        if (!havePlayed)
        {
            vase = GetComponent<AudioSource>();
            vase.Play();
            havePlayed = true;



            vaseNotBroken.SetActive(false);
            vaseBroken.SetActive(true);
            StartCoroutine(waiter());


            

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        vaseBroken.SetActive(false);
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        Lamp1.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp2.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp3.GetComponent<LightController>().lightSwitch();
        VaseLamp.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp4.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp5.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp6.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp7.GetComponent<LightController>().lightSwitch();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
