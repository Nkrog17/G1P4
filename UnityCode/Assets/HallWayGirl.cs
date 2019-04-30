using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallWayGirl : MonoBehaviour
{


    public AudioSource light;
    bool havePlayed = false;

    public GameObject Lamp1;
    public GameObject Lamp2;
    public GameObject Lamp3;
    public GameObject Lamp4;
    public GameObject Lamp5;


    private void OnTriggerEnter(Collider collider)
    {
        light = GetComponent<AudioSource>();
        light.Play();

        Lamp1.GetComponent<LightController>().lightSwitch();
        Lamp2.GetComponent<LightController>().lightSwitch();
        Lamp3.GetComponent<LightController>().lightSwitch();
        Lamp4.GetComponent<LightController>().lightSwitch();
        Lamp5.GetComponent<LightController>().lightSwitch();

    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
