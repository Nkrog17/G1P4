using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarRaper : MonoBehaviour
{
	public AudioSource source;
	public GameObject SerialPort;
	public int spikeLimit;
    public CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(){
    	int spikes = 10; //SerialPort.GetComponent<SerialPortScript>().allSpikes
    	if(spikes > spikeLimit){
    		source.GetComponent<AudioSource>().volume = 1;
    	}
    	source.Play();
        StartCoroutine(cameraShake.Shake(.55f, .4f));
    }
}
