using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSoundTrigger : MonoBehaviour
{
    public GameObject vaseNotBroken;
    public GameObject vaseBroken;

    public AudioSource vase;
    bool havePlayed = false;

    private void OnTriggerEnter(Collider collider)
    {
        

        if (!havePlayed)
        {
            vase = GetComponent<AudioSource>();
            vase.Play();
            havePlayed = true;



            vaseNotBroken.SetActive(false);
            vaseBroken.SetActive(true);
            
            

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        vaseBroken.SetActive(false);
        

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
