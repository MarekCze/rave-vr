using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spheres = new GameObject[2];
    public Transform[] points = new Transform[4];
    public int counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpawn();
    }

    void CheckSpawn()
    {
        

        if(AudioData.GetBeatNew(1) - AudioData.GetBeatOld(1) > 0.3f)
        {
            //Debug.Log(AudioData.beatNew[1] - AudioData.beatOld[1]);
            GameObject instanceSphere = (GameObject)Instantiate(spheres[Random.Range(0, 2)]);
            instanceSphere.transform.position = points[Random.Range(0, 4)].transform.position;
            instanceSphere.transform.parent = this.transform;
            instanceSphere.name = "sphere" + counter;
            instanceSphere.AddComponent<MoveScript>();
            instanceSphere.AddComponent<Rigidbody>();
            instanceSphere.GetComponent<Rigidbody>().useGravity = false;

        }
    }

}
