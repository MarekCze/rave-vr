using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{

    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.name == "Points")
        {
            txt.text = "Score: " + Score.getPoints();
        }
        else
        {
            txt.text = "x" + Score.getCombo();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.name == "Points")
        {
            txt.text = "Score: " + Score.getPoints();
        }
        else
        {
            txt.text = "x" + Score.getCombo();
        }
    }
}
