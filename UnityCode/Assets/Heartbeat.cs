using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    public AudioSource heartbeat;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        heartbeat.PlayDelayed(1);
        heartbeat.loop = true;
        
    }
}
