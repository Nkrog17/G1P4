using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float playerSpeed = 2f;//Baseline for playerSpeed
    public float sensitivity = 1f;
    public GameObject camera;

    CharacterController player;
    float moveFB; //For moving Forwards/Backwards
    float moveLR;//For moving Left/Right
    float rotX;
    float rotY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveFB = Input.GetAxis("Vertical") * playerSpeed;//Defines the speed of the movement, and which button does the left/right
        moveLR = Input.GetAxis("Horizontal") * playerSpeed;//Defines the speed of the movement, and which button does the forward/backward

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        transform.Rotate(0, rotX, 0);
        camera.transform.Rotate(rotY, 0, 0);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
    }
}
