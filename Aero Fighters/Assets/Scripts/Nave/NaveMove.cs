using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    public bullet1 bullet1prefab;
    private float bulle1ttime;
    
    void Start()
    {
        this.bulle1ttime = 0;
    }

    void Update()
    {
        this.bulle1ttime += Time.deltaTime;
        if (this.bulle1ttime >= 0.1f)
        {
            this.bulle1ttime = 0f;

            if (Input.GetKey(KeyCode.Space))
            {
                Atirar();
            }
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.velocidadeMovimento);
        float velocidadeY = (vertical * this.velocidadeMovimento);
        
        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY);

    }

    private void Atirar()
    {
        Instantiate(this.bullet1prefab, this.transform.position, Quaternion.identity);
    }
    
    
    
    
    
    
}

//para fazer com que a nave principal passe a criar tiros a partir de si, tivemos que transformar o tiro em um prefab e fazermos a seguinte lógica: criar uma variável 
//para colocarmos esse prefab e uma variável pra contar o tempo, pois os tiros não saem aleatoriamente, mas sim em frações padronizadas de tempo, mas precisamos saber 
//quanto tempo ta se passando. pra isso, iniciamos a variavel de tempo com zero no start (o tempo começará a contar quando o jogo começar) e no update esse tempo vai 
//sendo incrementado a cada segundo. assim, conseguimos criar meio que um cronometro, pra saber quanto tempo tá se passando
//por que eu coloquei o prefab da bala simples vomo trigger?




































