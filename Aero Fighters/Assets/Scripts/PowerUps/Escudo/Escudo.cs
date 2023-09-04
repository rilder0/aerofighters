using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private static int escudohealth = 10; //vida do escudo
    bool x = true;
    NaveMove naveprincipal;

    void Start() 
    {
        escudohealth = 5;
    }

    void Update() 
    {
        Debug.Log("Vida do escudo = " + escudohealth);

        if(escudohealth < 0) {

            this.gameObject.SetActive(false);
            escudohealth = 0;
        }

        naveprincipal.EstaColidindoColetavel(x, escudohealth);
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
            if(escudohealth < 0) {
                escudohealth = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collission) {

        if(collission.CompareTag("obstacle")) {

            escudohealth--;
            Obstacles obstacles = collission.GetComponent<Obstacles>();
            obstacles.HealthAObstacles--;
            obstacles.DestroyObstacles(true);

            if(escudohealth < 0) {



            }



        }

        




    }
}
