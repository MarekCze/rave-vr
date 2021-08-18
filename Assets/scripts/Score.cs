using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static float combo = 0;
    private static float points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float getPoints()
    {
        return points;
    }

    public static void setPoints(float point)
    {
        points = point;
    }

    public static float getCombo()
    {
        return combo;
    }

    public static void setCombo(float c)
    {
        combo = c;
    }
}
