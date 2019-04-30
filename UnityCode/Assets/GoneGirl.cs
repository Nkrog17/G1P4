using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoneGirl : MonoBehaviour
{
    public GameObject bitch;
    public GameObject lamp;
    public GameObject door;
    public AudioSource knirk;
    public GameObject door9;
    Animator anim;
    Animator anim9;
    float timer = 0f;
    bool startTimer;
    bool knirkHavePlayed;
    
    bool havePlayed;
    public static bool door9IsClosed = true;
    public static bool ladyEventEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = door.GetComponent<Animator>();
        
        anim9 = door9.GetComponent<Animator>();
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (!havePlayed)
        {
            bitch.SetActive(false);
            lamp.GetComponent<LightController>().flicker = false;

            lamp.GetComponent<AudioSource>().Stop();
            lamp.GetComponent<LightController>().lightOff();
            havePlayed = true;
            startTimer = true;
        }
    }

       
    void Update()
    {
        if (startTimer == true) {
            timer += Time.deltaTime;
           
            if (timer >= 1.9f && timer <= 2.1f)
            {
                ladyEventEnd = true;
                anim.SetTrigger("doorOpen");
                doorClose2.isClosed = false;
                anim9.SetTrigger("door9Open");
                door9IsClosed = false;
            }
        }
    }
 }




