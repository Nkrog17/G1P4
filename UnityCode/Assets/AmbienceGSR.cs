using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceGSR : MonoBehaviour
{

    public AudioSource ambience;
    public GameObject serialPort;
    float gsr;
    float avgBlGsr;
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
            ambience.volume = 1 - ((avgBlGsr/100)*gsr)+0.25f;
        }
        else
        {
            ambience.volume = 0.25f;
        }

        if (ambience.volume > 1)
        {
            ambience.volume = 1;
        }
    }

    

    private void OnTriggerEnter(Collider collider)
    {
        
        ambience.Play();
        ambience.loop = true;
        
    }
}
