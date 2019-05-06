using System.Collections;
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
    float ladyTimer = 0f;
    float newLadyTimer = 0f;
    bool SpikeGSR;
    bool SpikeHR;

    bool coldoorpound;
    bool doorslam;
    bool vaseevent;
    bool ladyEvent;

    bool stopPound;
    bool stopSlam;
    bool stopVase;
    bool stopLady;



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
            if (SpikeGSR || SpikeHR)
            {
                if (SpikeHR)
                {
                    WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer + " spikeHR");
                }
                if (SpikeGSR)
                {
                    WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer + " spikeGSR");
                }
            }
            else
            {
                WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer);
            }
            newTimer = timer + 1;
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
        if (!stopLady)
        {
            ladyEvent = HallWayGirl.ladyEventStart;
        }

        if (coldoorpound == true || doorslam == true || vaseevent == true || ladyEvent == true)
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
        if (ladyEvent)
        {
            ladyTimer += Time.deltaTime;
            if (ladyTimer >= newLadyTimer)
            {
                WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer + " LadyEvent");
                newLadyTimer = ladyTimer + 1;
            }
            if (GoneGirl.ladyEventEnd)
            {
                ladyEvent = false;
                stopLady = true;

            }
        }
    }
    public void WriteToFile(string message)
    {
        using (System.IO.StreamWriter logFile = new System.IO.StreamWriter(@"abekatmed.txt", true))
        {
            logFile.WriteLine(message);
        }


    }
}
