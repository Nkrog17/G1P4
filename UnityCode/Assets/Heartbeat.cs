using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    public AudioSource heartBeat;
   public float speedRegulator;
    bool playHeartBeat;
    SerialPortScript heartRate;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //brug waitforseconds
        
        heartBeat.PlayDelayed(speedRegulator);
        heartBeat.loop = true;

        //while (playHeartBeat)
       // {
            
            //heartBeat.PlayDelayed(speedRegulator);

        //

        //if (heartRate.latestHR > 80)
        //{
           // playHeartBeat = true;
        //}
        


       // while (playHeartBeat) {
          //  speedRegulator = heartRate.latestHR;
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
