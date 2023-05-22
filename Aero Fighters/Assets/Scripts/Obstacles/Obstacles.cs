using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Rigidbody2D ObstacleRigidbody; //associar um rigidbody quando arrastar o código pro gameobject
    public float velocidadeMin; //velocidaes mínimas e máximas pra que a velocidade seja um n° aleatório entre elas
    public float velocidadeMax;
    private float velocidadeX;

    void Start()
    {
        this.velocidadeX = Random.Range(this.velocidadeMin, this.velocidadeMax); //definição da velocidade no eixo X
    }

    void Update()
    {
        this.ObstacleRigidbody.velocity = new Vector2(-this.velocidadeX, 0); //velocidade no eixo y = 0
    }
}
