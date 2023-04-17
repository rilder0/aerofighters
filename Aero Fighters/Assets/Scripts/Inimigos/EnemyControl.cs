using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public CaçaEstelar CaçaOriginal;
    private float timeAfter;
    void Start()
    {
        this.timeAfter = 0;
    }

    void Update()
    {
        this.timeAfter += Time.deltaTime;
        if (this.timeAfter >= 1f)
        {
            this.timeAfter = 0;

            Vector2 CaçaPosition = Camera.main.ViewportToScreenPoint(new Vector2(0, 0));
            //a cada 1 segundo se cria um novo inimigo
            Instantiate(this.CaçaOriginal);
        }
    }
}

//esse codigo serve pra 
//timeAfter é uma variavel que guarda o intervalo de tempo entre a criação de inimigos, ou seja, o tempo descorrido depois da criação de um inimigo a fim de criar outro.
//se esse tempo for = 1s, a cada 1 segundo um inimigo vai ser criado
//this.timeAfter += Time.deltaTime; é basicamente dar a variavel timeAfter a noção de como tempo real está passando, para que ele tenha essas informações e crie inimigos 
//no tempo real. o tempo real é obtido atraves da classe time e o metodo delta time. o incremento na variavel se justifica porque os segundos vao passando e se somando.
//o metodo instantiate é um metodo que cria um novo objeto, e passando como parametro um objeto que já existe, ele vai duplicar





































