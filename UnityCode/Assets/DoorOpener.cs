﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject doorSlamCol;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("doorClose");
    }

    void OnTriggerExit(Collider other)
    {
        anim.enabled = true;
    }

    void pauseAnim()
    {
        anim.enabled = false;
    }
}
