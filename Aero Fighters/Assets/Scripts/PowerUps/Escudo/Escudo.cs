using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private static int escudohealth = 10; //vida do escudo

    void Start() 
    {
        escudohealth = 5;
    }

    void Update() 
    {
        Debug.Log("Vida do escudo = " + escudohealth);
    }

    public int EscudoHealth
    {
        get
        {
            return escudohealth;
        }
        set
        {
            escudohealth = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collission) {

        




    }
}
