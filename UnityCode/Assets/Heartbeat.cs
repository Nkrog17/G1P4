using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    public AudioSource heartBeat;
    public float speedRegulator;
    bool playHeartBeat;
    public GameObject heartRate; //hearRate er bare en variabel der holder serialport script
    float hr;
    float playTimer = 0f;
    float timer = 0f;
    float eventTimer = 0f;
    bool bio;
    bool gsrSpike;
    bool hrSpike;
    bool coldoorpound;
    bool doorslam;
    bool vaseevent;
    bool stopPound;
    bool stopSlam;
    bool stopVase;

    float counter;
    float counter2;
    float counter3;




    // Start is called before the first frame update
    void Start()
    {
        bio = SerialPortScript.biofeedback;

    }

    // Update is called once per frame
    void Update()
    {
        if (bio)
        {
            HRbiofeedback();
        }
        else
        {
            HRnobiofeedback();
            
        }
        



        


    }
    void HRbiofeedback()
    {
        hr = heartRate.GetComponent<SerialPortScript>().latestHR;
        hrSpike = heartRate.GetComponent<SerialPortScript>().HRspikeNow;
        gsrSpike = heartRate.GetComponent<SerialPortScript>().GSRspikeNow;

        timer += Time.deltaTime;
        eventTimer += Time.deltaTime;
        


        if (hr != 0 && hr < 180 && hrSpike == true || gsrSpike == true)
        {
            if (timer >= playTimer)
            {
                heartBeat.Play();
                playTimer = timer + 60 / hr;
            }
        }
    }

    void HRnobiofeedback()
    {
        if (!stopPound)
        {
            coldoorpound = ColDoorPound.poundEventBool;
        }
        if (!stopSlam)
        {
            doorslam = ColDoorSlam.doorslamEventBool;
        }
        if (!stopVase) {
            vaseevent = VaseSoundTrigger.vaseEventBool;
        }

        if (coldoorpound == true || doorslam == true || vaseevent == true)
        {
            if (coldoorpound == true)
            {
                counter += Time.deltaTime;

                if (counter >= 1 && counter < 8 && counter >= playTimer)
                {
                    heartBeat.Play();
                    playTimer = counter + 60 / 120f;
                }
                else if(counter >=8)
                {
                    playTimer = 0;
                    coldoorpound = false;
                    stopPound = true;
                }
            }

            if (doorslam == true)
            {
                counter2 += Time.deltaTime;

                if (counter2 >= 1 && counter2 < 8 && counter2 >= playTimer)
                {
                   
                    
                    heartBeat.Play();
                    playTimer = counter2 + 60 / 120f;
                   
                }
                else if(counter2 >= 8)
                {
                    playTimer = 0;
                    doorslam = false;
                    stopSlam = true;
                }
                
            }

            if (vaseevent == true)
            {
                counter3 += Time.deltaTime;
             
                if (counter3 >= 1 && counter3 < 8 && counter3 >= playTimer)
                {
                    heartBeat.Play();
                    playTimer = counter3 + 60 / 120f;
                  
                }
                else if(counter3 >= 8){
                    playTimer = 0;
                    vaseevent = false;
                    stopVase = true;
                }
            }
        }
    }
}
