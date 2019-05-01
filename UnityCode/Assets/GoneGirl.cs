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
    public GameObject door4;
    public GameObject door7squeak;
    Animator anim;
    Animator anim9;
    Animator anim4;
    public AudioSource squeak;
    float timer = 0f;
    bool startTimer;
    bool knirkHavePlayed;
    bool havePlayedGoneGirl;
    
    bool havePlayed;
    public static bool door9IsClosed = true;
    public static bool ladyEventEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = door.GetComponent<Animator>();
        
        anim9 = door9.GetComponent<Animator>();

        anim4 = door4.GetComponent<Animator>();

        squeak = door7squeak.GetComponent<AudioSource>();
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
                if (!havePlayedGoneGirl)
                {
                    ladyEventEnd = true;
                    anim.SetTrigger("doorOpen");
                    squeak.PlayDelayed(0.4f);
                    doorClose2.isClosed = false;
                    anim9.SetTrigger("door9Open");
                    door9IsClosed = false;
                    anim4.SetTrigger("door4Close");
                    havePlayedGoneGirl = true;
                    ColDoorSlam.door4Open = false;
                }
            }
        }
    }
 }




