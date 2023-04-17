using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaçaEstelar : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float velocidadeMin;
    public float velocidadeMax;

    private float velocidadeY;
    void Start()
    {
        this.velocidadeY = Random.Range(this.velocidadeMin, this.velocidadeMax);
    }

    void Update()
    {
        this.rigidbody.velocity = new Vector2(-this.velocidadeY, 0);
    }
}

//o inimigo tera duas velocidades: uma máxima e uma mínima. a velocidade efetiva será a média entre elas
// o sinal de menos indica emm qual direção do eixo cartesiano o inimigo vai se movimentar, nesse caso, ele tá se movimento em valores de x negativos (para a esquerda)
//












