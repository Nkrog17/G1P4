using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public bool flicker = false;
    public bool flickerSoundPlayed = false;
    public bool binaryFlicker = false;
    bool lit = true;
    float maxLight;
    public Material offMaterial;
    public Material onMaterial;
    public GameObject childLight;
    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        maxLight = childLight.GetComponent<Light>().range;

        if (GetComponent<AudioSource>() != null)
        {
            m_AudioSource = GetComponent<AudioSource>(); //Loads the audio source if there is one.
            m_AudioSource.Stop(); //Stops the audio source
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flicker || binaryFlicker)
        {
            if (GetComponent<AudioSource>() != null && !flickerSoundPlayed)
            {
                m_AudioSource.Play();
                m_AudioSource.loop = true;
                flickerSoundPlayed = true;

            }
            if (Random.Range(0, 50) == 5)
            {
                lightSwitch();
            }
            if (lit && Random.Range(0, 2) == 1)
            {
                if (binaryFlicker)
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        lightSwitch();
                    }
                }
                else
                {
                    childLight.GetComponent<Light>().range = Random.Range(0, maxLight);
                }
            }
        }
    }

    public void lightSwitch()
    {
        if (lit)
        {
            lit = false;
            childLight.GetComponent<Light>().range = 0;
            GetComponent<Renderer>().material = offMaterial;
        }
        else
        {
            lit = true;
            childLight.GetComponent<Light>().range = maxLight;
            GetComponent<Renderer>().material = onMaterial;

        }
    }
}
