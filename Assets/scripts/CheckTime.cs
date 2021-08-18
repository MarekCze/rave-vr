using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTime : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
       MoveScript mk = other.GetComponent<MoveScript>();

        Debug.Log(mk.t);
    }
}
