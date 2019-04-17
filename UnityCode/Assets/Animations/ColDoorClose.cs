﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDoorClose : MonoBehaviour
{
    public GameObject door;
    Animator anim;

    void Start(){
        anim = door.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other){
        anim.SetTrigger("doorClose");
    }
}