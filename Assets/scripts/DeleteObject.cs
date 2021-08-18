using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{

    

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Score.setCombo(0);
    }
}
