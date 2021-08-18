using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSquares : MonoBehaviour
{
    public GameObject[] squares = new GameObject[9];
    GameObject[] av = new GameObject[32];
    public float startScale;
    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        int j = 0;
        for (int i = 0; i < 32; i++)
        {
            GameObject instanceSquare = (GameObject)Instantiate(squares[j]);
            instanceSquare.transform.parent = this.transform;
            instanceSquare.transform.position = this.transform.position;
            instanceSquare.name = "square" + i;
            instanceSquare.transform.localPosition = new Vector3(0, 0, i * -1.8f);
            av[i] = instanceSquare;

            if (i % 4 == 0)
            {
                j++;
            }
        }
        this.transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if(this.name == "AV")
        {
            for (int i = 0; i < 32; i++)
            {
                av[i].transform.Rotate((DelayedAudioData.normalizedFreqBand[i] * maxScale + startScale), 0, 0);
            }
        }
        else
        {
            for (int i = 0; i < 32; i++)
            {
                av[i].transform.Rotate(-(DelayedAudioData.normalizedFreqBand[i] * maxScale + startScale), 0, 0);
            }
        }
        
    }
}
