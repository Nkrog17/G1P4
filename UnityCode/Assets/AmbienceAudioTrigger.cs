using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceAudioTrigger : MonoBehaviour
{
    public float num;
    public GameObject AmbienceTrigger;
    public AudioSource ambience;
    // Start is called before the first frame update

    private void OnTriggerEnter()
    {
        
        
     
        
        ambience.Play();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
