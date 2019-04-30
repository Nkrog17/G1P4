using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorlocked : MonoBehaviour
{
    public GameObject door;
    public AudioSource lockedDoor;
    bool playLocked;

    // Start is called before the first frame update
    void Start()
    {

        lockedDoor = lockedDoor.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (doorClose2.isClosed == true)
        {
            playLocked = true;
        }
        if (doorClose2.isClosed == false)
        {
            playLocked = false;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (playLocked == true)
        {
            lockedDoor.Play();

        }
    }
}
