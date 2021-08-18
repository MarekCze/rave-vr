using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseLight : MonoBehaviour
{
    public float minIntensity, maxIntensity;
    Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = (DelayedAudioData.ampBuffer * (maxIntensity - minIntensity) + minIntensity);
    }
}
