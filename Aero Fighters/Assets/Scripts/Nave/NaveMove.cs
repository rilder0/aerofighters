using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject LocalBullets; //local em que os tiros serão disparados
    
    private int BulletSelected = 0; //0 = tiro simples;; 1 = tiro 2;;  2 = tiro 3

    public new Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    private float bulle1ttime;
    public int RestHealths; //vidas restantes
    
    private int health; //variavel que guarda a quantidade de vidas atuais (n a quantidade de vidas restantes)
    public HealthBar healthbar; //variavel do tipo Healthbar pra acessar os métodos dessa classe

    public GameObject bulletPf;
    public GameObject bullet1Pf;
    public GameObject bullet2Pf;
    public GameObject bullet3Pf;

    public GameObject ImagemSelecaoB1;
    public GameObject ImagemSelecaoB2;
    public GameObject ImagemSelecaoB3;
    
    
    
    
    
    void Start()
    {
        this.RestHealths = 5;
        this.health = 5;
        this.bulle1ttime = 0;
        PointsControlr.Pontuation = 0; //jogador inicia com pontuacao = 0
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            BulletSelected = (BulletSelected + 1) % 3;
        }
        
        
        
        if(this.health <= 0 && this.RestHealths >= 0) {   //caso a vida chegue a zero, mas ainda tenha vidas restantes
            this.health = 5;                              //a barra de vida recomeça valendo 5 (o hp enche de novo)
            this.RestHealths--;                           //e uma vida é retirada
        }

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

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("obstacle"))
        {
            health--;
            Obstacles obstacles = collission.GetComponent<Obstacles>();
            obstacles.DestroyObstacles(false);

        }
        if (collission.CompareTag("CaçaEstelar"))
        {
            health--;
            CaçaEstelar caçaestelar = collission.GetComponent<CaçaEstelar>();
            caçaestelar.DestroyCaça(false);
        }

        if (collission.CompareTag("AttackShip"))
        {
            health -= 2;
            AttackShip attackship = collission.GetComponent<AttackShip>();
            attackship.DestroyAttackShip(false);
        }

        if (collission.CompareTag("BattleCruiser"))
        {
            health -= 2;
            BattleCruiser battlecruiser = collission.GetComponent<BattleCruiser>();
            battlecruiser.DestroyBattleCruiser(false); //impedir que o battlecruiser se destrua quando tocar com o jogador

        }


    }
    
    public int Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
            if (this.health <= 0)
            {
                this.health = 0;
            }
        }
    }    
    private void Atirar()
    {
        switch (BulletSelected) 
        {
            case 0:
                bulletPf = bullet1Pf;
                break;
            case 1:
                bulletPf = bullet2Pf;
                break;
            case 2:
                bulletPf = bullet3Pf;
                break;
            default:
                bulletPf = bullet1Pf;
                break;
        }

        Instantiate(this.bulletPf, this.transform.position, Quaternion.identity);
        //Instantiate(this.bullet1prefab, this.transform.position, Quaternion.identity);
    }    
}

//para fazer com que a nave principal passe a criar tiros a partir de si, tivemos que transformar o tiro em um prefab e fazermos a seguinte lógica: criar uma variável 
//para colocarmos esse prefab e uma variável pra contar o tempo, pois os tiros não saem aleatoriamente, mas sim em frações padronizadas de tempo, mas precisamos saber 
//quanto tempo ta se passando. pra isso, iniciamos a variavel de tempo com zero no start (o tempo começará a contar quando o jogo começar) e no update esse tempo vai 
//sendo incrementado a cada segundo. assim, conseguimos criar meio que um cronometro, pra saber quanto tempo tá se passando
//por que eu coloquei o prefab da bala simples como trigger? o que significa coloar algo como trigger? quando o bullet1 colidia com o inimigo, como ambos estao sob os efeitos da fisica, 
//quando um entra no circulo de colisao um do outro, eles sofrem efeitos da fisica de colisões. tornar um prefab trigger significa que vamos camuflar os efeitos da fisica, tipo
//havera a colisão, mas ela será uma colisao meio plastica, perfeita, sem efeitos da fisica, mas o fato de um entrar no ambiente de colisão do outro será registrado. tornar trigger 
//significa dizer pra gente que uma colisao ta ocorrendo, mas sem os efeitos da fisica

//dps que eu fiz o codigo das barras de vida, quando a nave principal colidia com o caça estelar, sumia 2 ou até 3
//barrinhas de vida. as barrinhas de vida estavam associadas às vidas do jogador, tipo, a vida começava com 5 e 
//conforme a colisão entre a nave e o caça estelar é registrada, uma vida é retirada, e onsequentemente, uma barrinha de
//vida também. o que tava acontecendo era que o caça estelar e a nave tavam cheio de colisores, e dependendo do angulo
//que a nave atingia o caça estelar, batia em mais de um colisor, aí a colisão era contada mais de uma vez. a solução pra 
//isso foi deixar um colisor pra cada, mas nem o box collider e o circle collider não se encaixavam no design das duas naves
//aí eu descobri o edge collider 2d, que é um collider 2D que você consegue desenhar em volta (nas bordas, por isso o nome edge)
//da nave



































