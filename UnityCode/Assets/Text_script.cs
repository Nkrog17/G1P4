using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_script : MonoBehaviour
{
    public GameObject mText;
    public TextMesh writeText;

    float awakeTime = 0f;
    bool textNotShown = false;
    float stopText = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        mText.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
      
        if (SerialPortScript.baseLine == false && textNotShown == false)
        {
            
            mText.SetActive(true);

            stopText += Time.deltaTime;

            if (stopText >= 5) {
                Debug.Log("put them up punk");
                mText.SetActive(false);
                textNotShown = true;
            }

        }
        Debug.Log(stopText);
    }
}
