using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBars : MonoBehaviour {

    public GameObject barPrefab;
    GameObject[,] speakers = new GameObject[4, 8];
    public float startScale;
    public float maxScale;

    // Use this for initialization
    void Start () {
        GameObject instanceSpeaker = (GameObject)Instantiate(barPrefab);
        if (this.name == "SpeakerArray1")
        {
            Debug.Log(this.name);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    instanceSpeaker = (GameObject)Instantiate(barPrefab);
                    instanceSpeaker.transform.position = this.transform.position;
                    instanceSpeaker.transform.parent = this.transform;
                    instanceSpeaker.name = "speaker" + i + "" + j;                   
                    this.transform.localEulerAngles = new Vector3(0,90,0);
                    instanceSpeaker.transform.Rotate(0, 90, 0);
                    speakers[i, j] = instanceSpeaker;

                    speakers[0, 0].transform.Rotate(47.9f, 0, 0);
                }

            }
        }
        else if (this.name == "SpeakerArray2")
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    instanceSpeaker = (GameObject)Instantiate(barPrefab);
                    instanceSpeaker.transform.parent = this.transform;
                    instanceSpeaker.transform.position = this.transform.position;
                    instanceSpeaker.name = "speaker" + i + "" + j;                 
                    this.transform.localEulerAngles = new Vector3(0, -90, 0);
                    instanceSpeaker.transform.Rotate(0, -90, 0);
                    speakers[i, j] = instanceSpeaker;

                    speakers[0, 0].transform.Rotate(47.9f, 0, 0);
                }

            }
        }
        else if (this.name == "SpeakerArray3")
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    instanceSpeaker = (GameObject)Instantiate(barPrefab);
                    instanceSpeaker.transform.parent = this.transform;
                  //  instanceSpeaker.transform.position = this.transform.position;
                    instanceSpeaker.name = "speaker" + i + "" + j;
                    this.transform.localEulerAngles = new Vector3(0, 45, 0);
                    instanceSpeaker.transform.Rotate(45, 90, 0);
                    speakers[i, j] = instanceSpeaker;

                    speakers[0, 0].transform.Rotate(46.4f, 0, 0);
                }

            }
        }
        else if (this.name == "SpeakerArray4")
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    instanceSpeaker = (GameObject)Instantiate(barPrefab);
                    instanceSpeaker.transform.parent = this.transform;
                    instanceSpeaker.transform.position = this.transform.position;
                    instanceSpeaker.name = "speaker" + i + "" + j;
                    this.transform.localEulerAngles = new Vector3(0, -45, 0);
                    instanceSpeaker.transform.Rotate(45, -90, 0);
                    speakers[i, j] = instanceSpeaker;

                    speakers[0, 0].transform.Rotate(46.4f, 0, 0);
                }

            }
        }

    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if (speakers != null)
                {
                    if(this.name == "SpeakerArray3" || this.name == "SpeakerArray4")
                    {
                        speakers[i, j].transform.localPosition = new Vector3(j * 3, i * 3, DelayedAudioData.normalizedFreqBandBuffer2D[i, j]);
                    }
                    else
                    {
                        speakers[i, j].transform.localPosition = new Vector3(j * 8, i * 8, DelayedAudioData.normalizedFreqBandBuffer2D[i, j]);
                    }
                    
                    

                    speakers[i,j].transform.localScale = new Vector3(DelayedAudioData.normalizedFreqBandBuffer2D[i, j] * maxScale + startScale, DelayedAudioData.normalizedFreqBandBuffer2D[i,j] * maxScale + startScale, DelayedAudioData.normalizedFreqBandBuffer2D[i, j] * maxScale + startScale);
                    
                }
            }
            
        }

        
    }
}
