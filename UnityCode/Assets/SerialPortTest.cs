using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialPortTest : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM5", 9600);
    List<int> allHR = new List<int>();
    List<int> allGSR = new List<int>();
    int baselineReadAmt = 10;
    static int HRLvl = 1; //Static so it can be given to other classes without creating an object.
    int baselineHR = 0;
    int HRSum = 0;
    


    void Start()
    {
        stream.Open();
    }
    void Update()
    {
        string value = stream.ReadLine();
        // value in Ardiuno SKAL være HR= eller GSR=        
        // Split string, value, at '='
        string[] splitStrings = value.Split('=');

        // Add value to either allHR or allGSR depending on type.
        if (splitStrings[0].Equals("HR"))
        {
            allHR.Add(int.Parse(splitStrings[1]));
            Debug.Log("HR = " + splitStrings[1]);

            if (allHR.Count == baselineReadAmt)
            {
                for (int i = 0; i < 10; i++)
                {
                    HRSum = HRSum + allHR[i];

                }
                baselineHR = HRSum / baselineReadAmt;
            }
            if (allHR.Count > baselineReadAmt && allHR[allHR.Count] > baselineHR * (1 + HRLvl / 10))
            {
                //Suspense lvl up.
                HRLvl++;

            }

            /* if (allHR.Count >= 2 && allHR[allHR.Count] > allHR[allHR.Count -1] * 1.1){
                 //SPIKE.
             } */
        }
        else if (splitStrings[0].Equals("GSR"))
        {
            allGSR.Add(int.Parse(splitStrings[1]));
            Debug.Log("GSR = " + splitStrings[1]);
        }


        //Der skal ske noget lydændring her. i.e. kald Sound effect funktionen.noget lignende: soundLevel(HRLvl, GSRLvl).
        //Det kan evt også være noget booleans som ændrer hvilken lydfil der bliver brugt forskellige steder.
    }

    public static int getLvl()
    {
        return HRLvl;
    }

    
}
