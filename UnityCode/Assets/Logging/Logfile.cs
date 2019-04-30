﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logfile : MonoBehaviour
{
    public GameObject serialport;
    int SPSHR;
    int SPSGSR;
    float timer = 0.0f;
    float newTimer = 0.0f;
    bool SpikeGSR;
    bool SpikeHR;

    bool coldoorpound;
    bool doorslam;
    bool vaseevent;

    bool stopPound;
    bool stopSlam;
    bool stopVase;



    // Start is called before the first frame update
    void Start()
    {
        //SPSHR = serialport.GetComponent<SerialPortScript>().latestHR;
        // SPSGSR = serialport.GetComponent<SerialPortScript>().latestGSR;
        //WriteToFile("HR="+SPSHR+" GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer);
    }
    private void Update()
    {
        SpikeGSR = serialport.GetComponent<SerialPortScript>().GSRspikeNow;
        SpikeHR = serialport.GetComponent<SerialPortScript>().HRspikeNow;

        timer += Time.deltaTime;

        if (timer >= newTimer)
        {
            SPSHR = serialport.GetComponent<SerialPortScript>().latestHRLog;
            SPSGSR = serialport.GetComponent<SerialPortScript>().latestGSRLog;
            WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer);

            newTimer = timer + 1;
        }
        if (SpikeGSR || SpikeHR)
        {
            if (SpikeHR)
            {
                WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer + "spikeHR");
            }
            if (SpikeGSR)
            {
                WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer + "spikeGSR");
            }
        }

        if (!stopPound)
        {
            coldoorpound = ColDoorPound.poundEventBool;
        }
        if (!stopSlam)
        {
            doorslam = ColDoorSlam.doorslamEventBool;
        }
        if (!stopVase)
        {
            vaseevent = VaseSoundTrigger.vaseEventBool;
        }

        if (coldoorpound == true || doorslam == true || vaseevent == true)
        {
            eventTrigger();
        }


    }

    void eventTrigger()
    {
        if (coldoorpound)
        {
            WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer + " PoundEvent");
            coldoorpound = false;
            stopPound = true;

        }

        if (doorslam)
        {
            WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer + " SlamEvent");
            doorslam = false;
            stopSlam = true;
        }

        if (vaseevent)
        {
            WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer + " VaseEvent");
            vaseevent = false;
            stopVase = true;
        }
    }
    public void WriteToFile(string message)
    {
        using (System.IO.StreamWriter logFile = new System.IO.StreamWriter(@"Assets/Logging/LogFile.txt", true))
        {
            logFile.WriteLine(message);
        }


    }
}
