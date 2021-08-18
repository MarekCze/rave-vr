using MK.Glow.Legacy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    public MKGlowLite mk;
    public float minIntensity;
    public float maxIntensity;

    // Start is called before the first frame update
    void Start()
    {
        //mk = Camera.main.GetComponent<MKGlowLite>();
    }

    // Update is called once per frame
    void Update()
    {
        mk.bloomIntensity = (DelayedAudioData.ampBuffer * (maxIntensity - minIntensity) + minIntensity);
    }
}
