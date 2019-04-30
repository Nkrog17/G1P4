using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallWayGirl : MonoBehaviour
{


    public AudioSource light;
    bool havePlayed = false;

    public GameObject Lamp1;
    public GameObject Lamp2;
    public GameObject Lamp3;
    public GameObject Lamp4;
    public GameObject Lamp5;

    public GameObject Bitch;
    public GameObject wallBlocker;
    // bool lamp5flicker;
    public static bool passBool = false;
    public static bool ladyEventStart = false;

    





    private void OnTriggerEnter(Collider collider)
    {
        if (!havePlayed)
        {
            ladyEventStart = true;
            light = GetComponent<AudioSource>();
            light.Play();

            Lamp1.GetComponent<LightController>().lightSwitch();
            Lamp2.GetComponent<LightController>().lightSwitch();
            Lamp3.GetComponent<LightController>().lightSwitch();
            Lamp4.GetComponent<LightController>().lightSwitch();
            Lamp5.GetComponent<LightController>().lightSwitch();

            havePlayed = true;


            StartCoroutine(waiter());
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        Bitch.SetActive(false);
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        Bitch.SetActive(true);
        yield return new WaitForSeconds(3);
        passBool = true;
        Lamp5.GetComponent<LightController>().lightSwitch();
        Lamp5.GetComponent<AudioSource>().Play();
        Lamp5.GetComponent<LightController>().flicker = true;
        


    }
    // Update is called once per frame
    void Update()
    {
      if(passBool == true)
        {
            wallBlocker.SetActive(false);
        }
    }
}
