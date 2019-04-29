using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceGSR : MonoBehaviour
{

    public AudioSource ambience;
    public GameObject serialPort;
    float gsr;
    float avgBlGsr;
    float ambVolume = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        avgBlGsr = serialPort.GetComponent<SerialPortScript>().avgGSRbaseLine;
        gsr = serialPort.GetComponent<SerialPortScript>().latestGSR;

        if (serialPort.GetComponent<SerialPortScript>().GSRspikeNow)
        {

            ambVolume = 1 - ((avgBlGsr/100)*gsr)+0.25f;
        }
        else
        {
            ambVolume = 0.25f;
        }
        if (ambVolume > 1)
        {
            ambVolume = 1;
        }
        Debug.Log("ambVolume = " + ambVolume);
        ambience.volume = ambVolume;
        Debug.Log("realAmbVolume = " + ambience.volume);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        
        ambience.Play();
        ambience.loop = true;
        
    }
}
