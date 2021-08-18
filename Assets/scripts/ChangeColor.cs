using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = myMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
