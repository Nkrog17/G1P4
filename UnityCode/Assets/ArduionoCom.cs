using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialPortTest : MonoBehaviour {
    SerialPort stream = new SerialPort("COM5", 9600);
    ArrayList allHR = new ArrayList();
    ArrayList allGSR = new ArrayList();
    
    void Start(){
        stream.Open();
    }
    void Update(){
        string value = stream.ReadLine();
        // value in Ardiuno SKAL være HR= eller GSR=        
        // Split string, value, at '='
        string[] splitStrings = value.Split('=');

        // Add value to either allHR or allGSR depending on type.
        if (splitStrings[0].Equals("HR")){
            allHR.Add(int.Parse(splitStrings[1]));
            Debug.Log("HR = " + splitStrings[1]);
        }
        else if (splitStrings[0].Equals("GSR")){
            allGSR.Add(int.Parse(splitStrings[1]));
            Debug.Log("GSR = " + splitStrings[1]);
        }
    }
}
