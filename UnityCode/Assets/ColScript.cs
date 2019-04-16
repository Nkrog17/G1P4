using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColScript : MonoBehaviour
{
    public GameObject door;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("doorClose");
    }

    void PauseAnimation(){
    	anim.enabled = false;
    }
}
