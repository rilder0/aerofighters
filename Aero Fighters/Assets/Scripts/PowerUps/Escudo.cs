using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private static int escudohealth = 10; //vida do escudo

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.CompareTag("Player")) {

            NaveMove jogador = collision.GetComponent<NaveMove>();
            if(jogador != null) {


            }

        }


        
    }
}
