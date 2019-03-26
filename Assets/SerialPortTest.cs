using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialPortTest : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM5", 9600);

    int indexArd = 0;

    void Start()
    {
        stream.Open();
    }

    void Update()
    {

        string value = stream.ReadLine();
        indexArd = int.Parse(value);
        Debug.Log(indexArd);
        
    }

    void OnGUI()
    {
        string newString = "Connected: " + indexArd;
        GUI.Label(new Rect(10, 10, 100, 50), newString);

    }

}
