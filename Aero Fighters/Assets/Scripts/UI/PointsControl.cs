using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointsControlr
{

    private static int points;

    public static int Pontuation
    {
        get
        {
            return Pontuation;
        }
        set
        {
            Pontuation = value;
            if (Pontuation < 0)
            {
                Pontuation = 0;
            }
        }
    }
}
