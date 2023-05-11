using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointsControlr
{
    
    private static int points = 0;

    public static int Pontuation
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            if (points < 0)
            {
                points = 0;
            }
            Debug.Log("Pontuação = " + Pontuation);
        }
    }
}

//























