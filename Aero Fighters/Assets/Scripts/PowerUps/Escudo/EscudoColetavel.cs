using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoColetavel : MonoBehaviour
{

    public Rigidbody2D EscudoRig; //associar um rigidbody quando arrastar o código pro gameobject
    private float velocidadeMin = 5; //velocidaes mínimas e máximas pra que a velocidade seja um n° aleatório entre elas
    private float velocidadeMax = 6;
    private float velocidadeX; //velocidade no eixo x
    
    void Start()
    {
        this.velocidadeX = Random.Range(this.velocidadeMin, this.velocidadeMax); //definição da velocidade no eixo X
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.CompareTag("Player")) {
            Destroy(this.gameObject); //destruir o coletável de esc
        }
    }

    void Update()
    {
        this.EscudoRig.velocity = new Vector2(-this.velocidadeX, 0); //velocidade no eixo y = 0
    }    

}
