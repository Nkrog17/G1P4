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
    bool SpikeGSR;
    bool SpikeHR;

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
            //Debug.Log("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer);




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


    }

    public void WriteToFile(string message)
    {
        using (System.IO.StreamWriter logFile = new System.IO.StreamWriter(@"Assets/Logging/LogFile.txt", true))
        {
            logFile.WriteLine(message);
        }


    }
}
