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
    
    // Start is called before the first frame update
    void Start()
    {   
        //SPSHR = serialport.GetComponent<SerialPortScript>().latestHR;
       // SPSGSR = serialport.GetComponent<SerialPortScript>().latestGSR;
        //WriteToFile("HR="+SPSHR+" GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer);
    }
    private void Update()
    {
        SPSHR = serialport.GetComponent<SerialPortScript>().latestHR;
        SPSGSR = serialport.GetComponent<SerialPortScript>().latestGSR;
        timer += Time.deltaTime;
        
        WriteToFile("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer);
        Debug.Log("HR=" + SPSHR + " GSR=" + SPSGSR + " (X,Y,Z)=" + GameObject.Find("FPSController").transform.position + " Time=" + timer);
        
    }

    public void WriteToFile(string message)
    {
        using (System.IO.StreamWriter logFile = new System.IO.StreamWriter(@"Assets/Logging/LogFile.txt", true))
        {
            logFile.WriteLine(message);
        }
           
        
    }
}
