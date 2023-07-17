using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet3 : MonoBehaviour
{
    public Rigidbody2D Bullet3rigidbody;
    public float bullet3velocityX;
    
    private float TimetoDestroyBullet3; //variavel que guarda o tempo pra bala do jogador ser destruída (ela tem alcance limitado)
    
    void Start()
    {
        this.TimetoDestroyBullet3 = 0; //começa com 0 segundos
        this.Bullet3rigidbody.velocity = new Vector2(bullet3velocityX, 0);
    }

    void Update()
    {
        this.TimetoDestroyBullet3 += Time.deltaTime; //aumenta 1s 
        if(this.TimetoDestroyBullet3 >= 0.5f) { //quando se passar meio segundo, a contagem zera de novo pra um novo ciclo 
            TimetoDestroyBullet3 = 0;           // e o gameobject que esse script tá associado (bullet1) é destruído
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

        if (collision.CompareTag("obstacle"))
        {
            Obstacles obstacles = collision.GetComponent<Obstacles>();
            obstacles.HealthAObstacles -= 1;
            Destroy(this.gameObject);
            if (obstacles.HealthAObstacles <= 0)
            {
                obstacles.DestroyObstacles(true);
            }
        }

        if (collision.CompareTag("BattleCruiser"))
        {
            BattleCruiser battclecruiser = collision.GetComponent<BattleCruiser>();
            battclecruiser.HealthBattcleCruiser -= 8;
            if (battclecruiser.HealthBattcleCruiser <= 0)
            {
                battclecruiser.DestroyBattleCruiser(true);
            }
        }
    }
}
