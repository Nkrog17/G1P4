using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    public AudioSource heartBeat;
    public float speedRegulator;
    bool playHeartBeat;
    public GameObject heartRate;
    float hr;
    float playTimer = 0f;
    float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        hr = heartRate.GetComponent<SerialPortScript>().latestHR;
        timer += Time.deltaTime;
        if (timer >= playTimer)
        {
            if (hr != 0 && hr < 180)
            {
                heartBeat.Play();
                playTimer = timer + 60 / hr;
                Debug.Log(hr);
            }
            else
            {
                //Debug.Log("hej");
            }
        }


    }
}
