using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoneGirl : MonoBehaviour
{
    public GameObject bitch;
    public GameObject lamp;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
   void OnTriggerEnter(Collider other)
    {
        bitch.SetActive(false);
        lamp.GetComponent<LightController>().flicker = false;
        
        lamp.GetComponent<AudioSource>().Stop();
        lamp.GetComponent<LightController>().lightOff();
    }
}
