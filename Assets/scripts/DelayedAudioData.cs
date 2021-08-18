using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAudioData : MonoBehaviour
{

    public float delay = 2.99f;
    AudioSource audioSource;
    // number of frequency samples
    public static float[] spectrum = new float[512];

    // ARRAYS FOR AUDIO VISUALIZER
    // dividing samples into 8 frequency bands
    public static float[] frequencyBand = new float[32];
    // adding a band buffer
    float[] bandBuffer = new float[32];
    // buffer decrease value
    public static float[] bufferDecrease = new float[32];
    // highest value for each band
    public static float[] freqBandHigh = new float[32];
    // band values from 0 - 1
    public static float[] normalizedFreqBand = new float[32];
    // audio band buffer values
    public static float[] normalizedFreqBandBuffer = new float[32];

    public static float[,] normalizedFreqBandBuffer2D = new float[4, 8];

    public static float amp, ampBuffer;

    float ampHigh;

    public float audioProfile;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(2.99f);
        AudioProfile(audioProfile);
    }

    // Update is called once per frame
    void Update()
    {

        GetSpectrumAudioSource();
        MakeFreqBands();
        BandBuffer();
        NormalizeFreqBands();
        GetSongAmp();
        ChangeTo2D();
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
    }

    void AudioProfile(float audioProfile)
    {
        for (int i = 0; i < 32; i++)
        {
            freqBandHigh[i] = audioProfile;
        }
    }

    // Add up all normalized frequencies and divide by highest amplitude to get overall amplitude between 0-1
    void GetSongAmp()
    {
        float currentAmp = 0;
        float currentAmpBuffer = 0;

        for (int i = 0; i < 32; i++)
        {

            currentAmp += normalizedFreqBand[i];
            currentAmpBuffer += normalizedFreqBandBuffer[i];

        }

        if (currentAmp > ampHigh)
        {
            ampHigh = currentAmp;

        }

        amp = currentAmp / ampHigh;
        ampBuffer = currentAmpBuffer / ampHigh;

    }

    // Normalize frequency bands by dividing current frequency by frequency high to get value between 0-1
    void NormalizeFreqBands()
    {
        for (int i = 0; i < 32; i++)
        {
            if (frequencyBand[i] > freqBandHigh[i])
            {
                freqBandHigh[i] = frequencyBand[i];
            }

            normalizedFreqBand[i] = (frequencyBand[i] / freqBandHigh[i]);
            normalizedFreqBandBuffer[i] = (bandBuffer[i] / freqBandHigh[i]);

        }
    }

    void ChangeTo2D()
    {
        int c = 0;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                normalizedFreqBandBuffer2D[i, j] = normalizedFreqBandBuffer[c];
                c++;
            }
        }

       // Debug.Log(normalizedFreqBandBuffer2D[0, 0]);
    }

    void BandBuffer()
    {
        for (int i = 0; i < 32; ++i)
        {
            if (bandBuffer[i] < frequencyBand[i])
            {
                bandBuffer[i] = frequencyBand[i];
                bufferDecrease[i] = 0.01f;
            }

            if (bandBuffer[i] > frequencyBand[i])
            {

                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void MakeFreqBands()
    {
        //total number of samples
        int sampleCount = 0;

        for (int f = 0; f < 32; f++)
        {
            // average of all samples in a given frequency band
            float avg = 0;
            // number of samples in each frequency band
            int numOfSamples = f;
            //Debug.Log(sampleCount);
            if (f == 0 || f == 1)
            {
                numOfSamples = 2;
            }
            //Debug.Log("f: " + f + "\tnumOfSamples: " + numOfSamples);
            for (int j = 0; j < numOfSamples; j++)
            {
                //Debug.Log("inside j loop " + sampleCount);
                avg += spectrum[sampleCount] * j;
                sampleCount++;
                //Debug.Log(sampleCount);
            }

            avg /= sampleCount;
            frequencyBand[f] = avg * (10);

        }

        //Debug.Log(frequencyBand[1]);
    }
}
