using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_script : MonoBehaviour
{
    public GameObject mText;
    public TextMesh writeText;

    float awakeTime = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        mText.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        //SerialPortScript.baseLine == false
        if (SerialPortScript.baseLine == false)
        {
            mText.SetActive(true);
        }
    }
}
