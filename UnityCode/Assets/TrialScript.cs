using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int HRLvl = SerialPortTest.getLvl();
        Debug.Log(HRLvl);
    }
}
