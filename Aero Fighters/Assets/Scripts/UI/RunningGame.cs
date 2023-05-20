using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningGame : MonoBehaviour
{
    public Text PointsText;
    public Text RestHealth;
    public HealthBar healthbar;

    private NaveMove navemove;

    private void Start() {

        this.navemove = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveMove>();
    }
    
    void Update()
    {
        this.healthbar.ShowLifes(this.navemove.Health);
        this.PointsText.text = PointsControlr.Pontuation.ToString();
        this.RestHealth.text = navemove.RestHealths.ToString();
        Debug.Log("Vidas = " + navemove.Health);
        Debug.Log("Vidas Restantes = " + navemove.RestHealths);
    }
}