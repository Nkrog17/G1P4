using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceAudioTrigger : MonoBehaviour
{
   
   
    public AudioSource ambience;

    private void OnTriggerEnter(Collider collider)
    {
       
        ambience.Play();
        ambience.loop = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        ambience = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
