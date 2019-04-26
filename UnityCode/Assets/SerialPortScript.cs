using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class SerialPortScript : MonoBehaviour
{
    Thread myThread; 
    SerialPort stream = new SerialPort("COM5", 9600);
    List<int> allHR = new List<int>();
    List<int> allGSR = new List<int>();
    List<int> HRtime = new List<int>();
    List<int> GSRtime = new List<int>();

    int GSRspikes;
    int HRspikes;
    public int allSpikes;
    public bool GSRspikeNow = false;
    public bool HRspikeNow = false;
    int GSRbackRead = 10;
    int HRbackRead = 3;
    int nonsenseGSR = 5;
    int nonsenseHR = 5;
    bool baseLine = true;

    public bool biofeedback = true;

    public int latestHR;
    public int latestHRLog;
    public int latestGSR;
    public int latestGSRLog;

    void Start()
    {
        //Start Arduino reading thread
        stream.Open();
        myThread = new Thread(new ThreadStart(GetArduino));
        myThread.Start();

    }

    // Kills the thread and prints the total time the applications has been running
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        myThread.Abort();
    }

    // Arduino thread sends data to DistributeData()
    private void GetArduino()
    {
        while (myThread.IsAlive)
        {
            string value = stream.ReadLine();
            DistributeData(value);
            
        }
    }

    void DistributeData(string value)
    {
        string[] splitStrings = value.Split('=');

        // Add value to either allHR or allGSR depending on type.
        if (splitStrings[0].Equals("HR"))
        {
            allHR.Add(int.Parse(splitStrings[1]));
            if(biofeedback){
            	latestHR = int.Parse(splitStrings[1]);
            }
            latestHRLog = int.Parse(splitStrings[1]);
            Debug.Log("HR er " + splitStrings[1]);
        }
        else if (splitStrings[0].Equals("GSR"))
        {
            allGSR.Add(int.Parse(splitStrings[1]));
            if(biofeedback){
            	latestGSR = int.Parse(splitStrings[1]);
            }
            latestGSRLog = int.Parse(splitStrings[1]);
            Debug.Log("GSR er " + splitStrings[1]);
        }
        else {
            Debug.Log("Oh shit.");
        }
    }

    // Update function runs every frame
    void Update()
    {
        if(Time.time > 60 && baseLine){
            baseLine = false;
            Debug.Log("Baseline er done!");
            Debug.Log(nonsenseGSR);
            Debug.Log(nonsenseHR);
        }
        if((allGSR.Count > GSRbackRead && allHR.Count > HRbackRead)){
        //if(allGSR.Count > GSRbackRead){
            RegisterSpike();
            allSpikes = HRspikes + GSRspikes;
        }
    }

    void RegisterSpike()
    {
        // Record spikes if base line is no longer being recorded.
        if(allGSR[allGSR.Count - GSRbackRead] - allGSR[allGSR.Count - 1] > nonsenseGSR){
            if(!GSRspikeNow){
                Debug.Log("Spike GSR");
                GSRspikeNow = true;
                if(!baseLine){
                    GSRspikes ++;
                } else{
                    nonsenseGSR = allGSR[allGSR.Count - GSRbackRead] - allGSR[allGSR.Count - 1];
                }
            }
        } else {
            GSRspikeNow = false;
        }

        if(allHR[allHR.Count - 1] - allHR[allHR.Count - HRbackRead] > nonsenseHR){
            if(!HRspikeNow){
                Debug.Log("Spike HR");
                HRspikeNow = true;
                if(!baseLine){
                    HRspikes ++;
                    } else {
                        nonsenseHR = allHR[allHR.Count - 1] - allHR[allHR.Count - HRbackRead];
                    }
                
            }
        } else {
            HRspikeNow = false;
        }
    }
     public void ResetSpikes(){
    	allSpikes = 0;
    	HRspikes = 0;
    	GSRspikes = 0;
    }
}