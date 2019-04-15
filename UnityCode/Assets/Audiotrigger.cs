using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerPoint : MonoBehaviour
{
    public float num;
    public GameObject trigger;
    public AudioSource audioClip;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            trigger.SetActive(true);
        }
        audioClip.Play();

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
