﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSoundTrigger : MonoBehaviour
{
    public GameObject vaseNotBroken;
    public GameObject vaseBroken;

    public CameraShake cameraShake;

    public AudioSource vase;
    public AudioSource slam;
    bool havePlayed = false;

    public GameObject Lamp1;
    public GameObject Lamp2;
    public GameObject Lamp3;
    public GameObject Lamp4;
    public GameObject Lamp5;
    public GameObject Lamp6;
    public GameObject Lamp7;
    public GameObject horrorScream;

    public GameObject VaseLamp;

    public static bool vaseEventBool;

    private void OnTriggerEnter(Collider collider)
    {


        if (!havePlayed)
        {
            vase = GetComponent<AudioSource>();
            vase.Play();
            havePlayed = true;
            vaseEventBool = true;



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
        horrorScream.GetComponent<AudioSource>().Play();
        StartCoroutine(cameraShake.Shake(6f, .1f));
        yield return new WaitForSeconds(2);
        slam.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3);
        Lamp1.GetComponent<AudioSource>().Play();
        Lamp1.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp2.GetComponent<AudioSource>().Play();
        Lamp2.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp3.GetComponent<AudioSource>().Play();
        Lamp3.GetComponent<LightController>().lightSwitch();
        VaseLamp.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp4.GetComponent<AudioSource>().Play();
        Lamp4.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp5.GetComponent<AudioSource>().Play();
        Lamp5.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp6.GetComponent<AudioSource>().Play();
        Lamp6.GetComponent<LightController>().lightSwitch();
        yield return new WaitForSeconds(1);
        Lamp7.GetComponent<AudioSource>().Play();
        Lamp7.GetComponent<LightController>().lightSwitch();
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
