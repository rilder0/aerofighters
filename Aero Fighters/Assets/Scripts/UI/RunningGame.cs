using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningGame : MonoBehaviour
{

    public Text PointsText;
    
    void Update()
    {
        this.PointsText.text = PointsControlr.Pontuation.ToString();
    }
}
