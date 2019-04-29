using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceAudioTrigger : MonoBehaviour
{

    public GameObject serialPort;
    public AudioSource ambience;

    float gsr;
    float avgBlGsr;
    float ambVolume = 0.0f;
    float timer = 0.0f;
    float bonnieTimer = 0.0f;


    private void OnTriggerEnter(Collider collider)
    {

        ambience.Play();
        ambience.loop = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        ambience = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SerialPortScript.biofeedback)
        {
            GSRBioTrue();
        }
        else{
            ambience.volume = 0.50f;
        }
        
    }

    void GSRBioTrue()
    {
        gsr = serialPort.GetComponent<SerialPortScript>().latestGSR;

        timer += Time.deltaTime;
        if (timer >= bonnieTimer)
        {
            Debug.Log("gsr = " + gsr);
            bonnieTimer = timer + 1;
        }
        if (SerialPortScript.baseLine == false)
        {
            //Debug.Log("avgGSR = " + avgBlGsr);
            avgBlGsr = serialPort.GetComponent<SerialPortScript>().avgGSRbaseLine;

            ambVolume = 1 - (1 / avgBlGsr * gsr) + 0.25f;
            if (ambVolume <= 0.25f)
            {
                ambVolume = 0.25f;
            }
            if (ambVolume > 1)
            {
                ambVolume = 1;
            }
            ambience.volume = ambVolume;
            Debug.Log("realAmbVolume = " + ambience.volume);

        }
    } 
}

