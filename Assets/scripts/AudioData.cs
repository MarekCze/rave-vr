using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioData : MonoBehaviour
{
    public static float startTime;

    AudioSource audioSource;
    // number of frequency samples
    static float[] spectrum = new float[512];

    float[] spectrumSample = new float[64];

    float[] spectrumSampleHigh = new float[64];

    static float[] normalizedSpectrumSample = new float[64];

    // ARRAYS FOR GAME OBJECTS
    static float[] beatOld = new float[64];
    static float[] beatNew = new float[64];

    public float audioProfile;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        audioSource = GetComponent<AudioSource>();
        AudioProfile(audioProfile);
        InitArray();
    }

    // Update is called once per frame
    void Update()
    {
        
        GetSpectrumAudioSource();
        InitSpectrumSample();
        NormalizeSpectrumSample();
    }

    void AudioProfile(float audioProfile)
    {
        for (int i = 0; i < 64; i++)
        {
            spectrumSampleHigh[i] = audioProfile;
        }
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
    }

    void InitSpectrumSample()
    {
        for(int i = 0; i < 64; i++)
        {
            spectrumSample[i] = spectrum[i];
        }
    }

    void NormalizeSpectrumSample()
    {
        for(int i = 0; i < 64; i++)
        {
            if(spectrumSample[i] > spectrumSampleHigh[i])
            {
                spectrumSampleHigh[i] = spectrumSample[i];
            }

            normalizedSpectrumSample[i] = spectrumSample[i] / spectrumSampleHigh[i];
            
            beatOld[i] = beatNew[i];
            beatNew[i] = normalizedSpectrumSample[i];
        }

        //Debug.Log("spectrum 2: " + normalizedSpectrumSample[1]);
    }


    void InitArray()
    {
        for (int i = 0; i < 64; i++)
        {
            beatOld[i] = 1;
            beatNew[i] = 1;
        }
    }

    public static float GetNormSpectrumSample(int i)
    {
        return normalizedSpectrumSample[i];
    }

    public static float GetBeatOld(int i)
    {
        return beatOld[i];
    }

    public static float GetBeatNew(int i)
    {
        return beatNew[i];
    }

    public static float GetSpectrum(int i)
    {
        return spectrum[i];
    }
}

