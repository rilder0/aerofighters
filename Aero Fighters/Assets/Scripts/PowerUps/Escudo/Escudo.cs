using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public int EscudoMaxHealth = 5; //vida do escudo
    public int EscudoActualHealth;

    public NaveMove naveprincipal;

    void Start() 
    {
        EscudoActualHealth = EscudoMaxHealth;
    }

    void Update() 
    {
        //Debug.Log("Vida do escudo = " + EscudoActualHealth);

        if(EscudoActualHealth <= 0) {

            naveprincipal.EscudoOff();
            EscudoActualHealth = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collission) {

        if(collission.CompareTag("obstacle")) {

            EscudoActualHealth--;
            Obstacles obstacles = collission.GetComponent<Obstacles>();
            obstacles.HealthAObstacles--;
            obstacles.DestroyObstacles(true);
        }

    }
}
