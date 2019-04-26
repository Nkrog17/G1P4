using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceGSR : MonoBehaviour
{

    public AudioSource ambience;
    public GameObject gsrReading;
    float gsr;
    // Start is called before the first frame update
    void Start()
    {
        ambience.volume = 0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        gsr = gsrReading.GetComponent<SerialPortScript>().latestGSR;

        //if (spike)
        //{
        //  ambience.volume = 1;
        // }
        // else {
        // ambience.volume=0.5f;
   // }

    }

    

    private void OnTriggerEnter(Collider collider)
    {
        
        ambience.Play();
        ambience.loop = true;
        
    }
}
