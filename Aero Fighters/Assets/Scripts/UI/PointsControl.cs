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

//esse script basicamente é pra fazer um controle dos pontos. criei uma variavel points começando com zero e alguns mecanismos basicos, como por exemplo: não existir pontuação negativa, ou seja, quando
//a pontuação for = 0, ela imediatamente se torna zero.























