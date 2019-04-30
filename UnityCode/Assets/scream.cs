using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scream : MonoBehaviour
{
    public AudioSource screamSound;
    bool havePlayed = false;

    private void OnTriggerEnter(Collider collider)
    {


        if (!havePlayed)
        {
            screamSound = GetComponent<AudioSource>();
            screamSound.Play();
            havePlayed = true;








        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}