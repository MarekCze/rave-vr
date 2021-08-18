using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public float range = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }
        // Update is called once per frame
        void Update()
        {
            RaycastHit pHit;
            if (Physics.Raycast(transform.position, transform.up, out pHit, range))
            {
                if(pHit.transform.name == "sphere1")
                {
                    Destroy(pHit.transform.gameObject);
                    Score.setCombo(Score.getCombo() + 1f);
                    Score.setPoints(Score.getPoints() + 10f + Score.getCombo());
                }
            }
            
        }
    
}
