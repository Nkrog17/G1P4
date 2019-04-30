using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoneGirl : MonoBehaviour
{
    public GameObject bitch;
    public GameObject lamp;
    public GameObject door;
    Animator anim;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        door = door.GetComponent<GameObject>();
        anim = door.GetComponent<Animator>();
    }
    

        // Update is called once per frame
        void OnTriggerEnter(Collider other)
    {
        bitch.SetActive(false);
        lamp.GetComponent<LightController>().flicker = false;
        
        lamp.GetComponent<AudioSource>().Stop();
        lamp.GetComponent<LightController>().lightOff();

        timer += Time.deltaTime;

        if (timer >= 2)
        {
            anim.SetTrigger("doorOpen");
        }

    }
  


}
