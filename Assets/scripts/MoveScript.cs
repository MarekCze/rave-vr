using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public float startTime;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * 32 * Time.deltaTime;

        t += Time.deltaTime;

        //Debug.Log(t);
    }
}
