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
    float counter;
    float counter2;
    float counter3;




    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        hr = heartRate.GetComponent<SerialPortScript>().latestHR;
        //bio = heartRate.GetComponent<SerialPortScript>().biofeedback;
        hrSpike = heartRate.GetComponent<SerialPortScript>().HRspikeNow;
        gsrSpike = heartRate.GetComponent<SerialPortScript>().GSRspikeNow;
        coldoorpound = ColDoorPound.poundEventBool;
        doorslam = ColDoorSlam.doorslamEventBool;
        vaseevent = VaseSoundTrigger.vaseEventBool;
        bio = SerialPortScript.biofeedback;

        Debug.Log("vaseevent is =" + vaseevent);


        timer += Time.deltaTime;
        eventTimer += Time.deltaTime;
        //Debug.Log(eventTimer);
        Debug.Log(counter);
        if (timer >= playTimer)
        {
            if (hr != 0 && hr < 180 && bio == true && hrSpike == true || gsrSpike == true)
            {
                heartBeat.Play();
                playTimer = timer + 60 / hr;
                Debug.Log(hr);
            }

            
            if (bio == false && coldoorpound==true || doorslam ==true || vaseevent ==true)

                
            {

                
                // skal evt reworkes. Åndsvag metode at få heartbeat til at spille på.
                if (coldoorpound == true)
                {
                    counter += Time.deltaTime;
                }
                if (counter >= 1 && counter < 1.3)
                {
                    heartBeat.Play();
                    playTimer = timer + 60 / 120f;
                    
                }


                if (doorslam == true)
                {
                    counter2 += Time.deltaTime;
                }
                if (counter2 >= 1 && counter2 < 1.3)
                {
                    heartBeat.Play();
                    playTimer = timer + 60 / 120f;

                }

                if (vaseevent == true)
                {
                    counter3 += Time.deltaTime;
                }
                if (counter3 >= 1 && counter3 < 1.3)
                {
                    heartBeat.Play();
                    playTimer = timer + 60 / 120f;

                }
                //if ( timer>=2 && timer < 12)
                //{
                // heartBeat.Play();
                //playTimer = timer + 60 / 120f;
                /* if (eventTimer == 12)
                 {
                     eventTimer = 0;
                 }*/
                //Debug.Log("playtimer =" + playTimer + " timer =" + eventTimer);
                //Debug.Log(eventTimer);
                //}
                //Debug.Log("hej");

            }
            else
            {
                coldoorpound = false;
                doorslam = false;
                vaseevent = false;
            }
        }


    }
}
