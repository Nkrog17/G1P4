using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor4 : MonoBehaviour
{
    public GameObject door;
    public AudioSource lockedDoor;
    bool havePlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        
        lockedDoor = door.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (havePlayed == false)
        {
            lockedDoor.Play();
            havePlayed = true;
        }
    }
}
