using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class bullet1 : MonoBehaviour
{

    public Rigidbody2D Bullet1rigidbody;
    public float bullet1velocityX;

    private float TimetoDestroyBullet1; //variavel que guarda o tempo pra bala do jogador ser destruída (ela tem alcance limitado)

    void Start()
    {
        this.TimetoDestroyBullet1 = 0; //começa com 0 segundos
        this.Bullet1rigidbody.velocity = new Vector2(bullet1velocityX, 0);
    }

    void Update() 
    {
        this.TimetoDestroyBullet1 += Time.deltaTime; //aumenta 1s 
        if(this.TimetoDestroyBullet1 >= 0.5f) { //quando se passar meio segundo, a contagem zera de novo pra um novo ciclo 
            TimetoDestroyBullet1 = 0;           // e o gameobject que esse script tá associado (bullet1) é destruído
            Destroy(this.gameObject);
        }


    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CaçaEstelar"))
        {
            CaçaEstelar caçaestelar = collision.GetComponent<CaçaEstelar>();
            caçaestelar.DestroyCaça(true);
            Destroy(this.gameObject);
            
        }

        if(collision.CompareTag("AttackShip")) { //caso a bala do jogador colida com o attackship
            AttackShip attackShip = collision.GetComponent<AttackShip>(); //acessar os métodos do script attackship
            attackShip.HealthAttackShip -= 5; //quando a bala colidir com o attackhip, 5 vidas são retiradas
            Destroy(this.gameObject); //quando a bala colide com o gameobject com a tag "attackship" ele era destruido, pra evitar do bug de a bala atravessar o attackship
            if (attackShip.HealthAttackShip <= 0) {  //quando a vida do attackship = 0, chamar o método que destroi o attackship como verdade
                attackShip.DestroyAttackShip(true);
            }
        }
    }
}

//o que o metodo ontriggerenter2d faz? basicamente é um metodo que guarda a informação do primeiro instante da colisão, e ele guarda isso dentro de uma variavel collision do tipo collider2d
// como podemos fazer que, a partir do primeiro instante que a colisao ocorrer, ambos o tiro e o caçaestelar sejam destruidos? pra gente especificar quem sera destruido, temos que colocar tags 
//nos prefabs, pois a partir do metodo compare tag, o metodo destroy podera identificar quem esta com essa tag e destruilo, ou seja, quando a bala entrar na colisao com o inimigo, o objeto que a 
//bala colidiu, ou seja, o proprio inimigo, será destruido, bem como a prória bala;
//pra ajustarmos a pontuação, tive que mudar algumas coisas: quando a colisao ocorrer, uma pontuação deverá ser incrementada. esse metodo já existe, criei ele no script do inimigo, mas preciso acessar
//ele no metodo que registra a pontuação então: criei uma variavel do tipo do inimigo e fiz com que esse codigo da bala tivesse acesso ao script do inimigo, para aí sim chamarmos o metodo DestroyCaça que 
//incrementa a pontuação

//explicação da colisão com o attackship tá explicado lá no código mesmo




























