using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NaveMove : MonoBehaviour
{    
    private int BulletSelected = 0; //0 = tiro simples;; 1 = tiro 2;;  2 = tiro 3

    public new Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    private float bulle1ttime;
    public int RestHealths; //vidas restantes
    
    //pontos e vida
    private int health; //variavel que guarda a quantidade de vidas atuais (n a quantidade de vidas restantes)

    private int _points = 0;

    private int _currentEnergy;

    [SerializeField] private int maxEnergy = 100;

    private int MaxTenBulletMunicao = 10;
    private int _currentTenBulletMunicao = 10;

    public GameObject TiroAtual; //Prefab que vai ficar assumindo os prefab dos 3 tiros. É tipo um prefab vazio q vai receber vários prefabs
    public GameObject TiroFoguete; //Prefab do tiro foguete
    public GameObject TiroLaser; //Prefab do tiro laser
    public GameObject TiroRapido; //tiro simples. o de munição infinita.

    //variáveis do escudo
    private bool escudoAtivo = false; //verifica se o escudo tá ativo ou não
    public bool EstaColidindoEscudo = false;
    public GameObject escudoImagem; //Imagem do escudo
    public Escudo escudo;  

    //Variáveis para acessar métodos e atributos dos power ups
    public BulletControl bulletcontroll;
    
    void Start()
    {
        _currentEnergy = 100;
        maxEnergy = 100;
        _points = 0;
        MaxTenBulletMunicao = 10;
        _currentTenBulletMunicao = 10;
        this.RestHealths = 5;
        this.health = 5;
        this.bulle1ttime = 0;
        this.escudoAtivo = false;
        escudoImagem.SetActive(false);
        //PointsControlr.Pontuation = 0; //jogador inicia com pontuacao = 0
    }

    void Update()
    {
        Debug.Log("PONTUAÇÃO NOVA = " + _points);
        Debug.Log("VIDA ATUAL = " + _currentEnergy);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            BulletSelected = (BulletSelected + 1) % 3; 
        }
        
        
        
        if(this.Health <= 0 && this.RestHealths >= 0) {   //caso a vida chegue a zero, mas ainda tenha vidas restantes
            this.Health = 5;                              //a barra de vida recomeça valendo 5 (o hp enche de novo)
            this.RestHealths--;                           //e uma vida é retirada
        }

        this.bulle1ttime += Time.deltaTime;
        if (this.bulle1ttime >= 0.1f)
        {
            this.bulle1ttime = 0f;

            if (Input.GetKey(KeyCode.Space)) {

                AddPoints(10);
                /*if (BulletSelected == 0 && BulletControl.MuniçãoTiroRapido > 0) { //caso o usuario esteja clicando o botão de espaço, se ele tiver com uma bala
                                                                                  //específica selecionada e se ela tiver munição, aí pode atirar e remover uma 
                    Atirar();                                                     //munição em seguida
                }

                /*if(BulletSelected == 1 && BulletControl.MuniçãoTiroLaser > 0) {

                    Atirar();
                    BulletControl.MuniçãoTiroLaser--;

                }*/

                if (BulletSelected == 2 && _currentTenBulletMunicao > 0) {

                    Atirar();
                    TakeOffTenBullet(1);
                }
            }
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.velocidadeMovimento);
        float velocidadeY = (vertical * this.velocidadeMovimento);
        
        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY);

        //Debug.Log("Munição do tiro laser: " + BulletControl.MuniçãoTiroLaser);
        //AddEscudo(EstaColidindoEscudo, escudo.escudohealth);
    }

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("obstacle"))
        {
            AddEnergy(1);
            if(escudoAtivo == false) {
            health--;
            Obstacles obstacles = collission.GetComponent<Obstacles>();
            obstacles.HealthAObstacles--;
            obstacles.DestroyObstacles(false);
            }
        }
        if (collission.CompareTag("CaçaEstelar"))
        {
            if (escudoAtivo == false)
            {
                health--;
                CaçaEstelar caçaestelar = collission.GetComponent<CaçaEstelar>();
                caçaestelar.DestroyCaça(false);

            }
        }

        if (collission.CompareTag("AttackShip"))
        {
            if (escudoAtivo == false)
            {
                health -= 2;
                AttackShip attackship = collission.GetComponent<AttackShip>();
                attackship.DestroyAttackShip(false);            }
        }

        if (collission.CompareTag("BattleCruiser"))
        {
            if (escudoAtivo == false)
            {
                health -= 2;
                BattleCruiser battlecruiser = collission.GetComponent<BattleCruiser>();
                battlecruiser.DestroyBattleCruiser(false); //impedir que o battlecruiser se destrua quando tocar com o jogador
            }

        }

        if(collission.CompareTag("EscudoColetavel")) 
        {
            EstaColidindoEscudo = true;
            EscudoOn();
            escudoAtivo = true;

            if(escudo.EscudoActualHealth <= 0) {
                EscudoOn();
                escudo.EscudoActualHealth = escudo.EscudoMaxHealth;
            }
            if(escudo.EscudoActualHealth > 0 && escudoAtivo == true) {

                escudo.EscudoActualHealth = escudo.EscudoMaxHealth;
            }
        }

        if(collission.CompareTag("FogueteColetavel")) {

            BulletControl.MuniçãoTiroFoguete = BulletControl.MuniçãoTiroFogueteMax; //Caso o jogador colida com o power up de munição do tiro foguete, a
                                                                                    //a munição atual volta a ser a munição máxima
        }

        if(collission.CompareTag("LaserColetavel")) {

            BulletControl.MuniçãoTiroLaser = BulletControl.MuniçãoTiroLaserMax;
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
                TiroAtual = TiroRapido;
                break;
            
            case 1:
                TiroAtual  = TiroLaser;
                break;

            case 2:
                TiroAtual = TiroFoguete;
                break;

            default:
                TiroAtual = TiroRapido;
                break;
        }

        Instantiate(this.TiroAtual, this.transform.position, Quaternion.identity);
    }    

    public void RemoveEscudo(int vidadoescudo) {

        if(vidadoescudo <= 0) {

            vidadoescudo = 0;
            EscudoOff();
        
        }

    }

    public void AddEscudo(bool tacolidindo, int vidaescudo) {

        //EscudoOn();
        if(vidaescudo == 0 && tacolidindo == true) {

            vidaescudo = 5;

        }
    }

    private void EscudoOn() {
        escudoAtivo = true;
        escudoImagem.SetActive(true);
    }

    public void EscudoOff() {

        escudoAtivo = false;
        escudoImagem.SetActive(false);
    }




    public void AddPoints(int pontos) {

         _points = Mathf.Clamp(_points + pontos, 0, 500);

        PlayerObserverManeger.PointsChanged(_points);


    }

    public void AddEnergy(int desconto) {

        _currentEnergy = Mathf.Clamp(_currentEnergy - desconto, 0, maxEnergy);

     PlayerObserverManeger.EnergyChanged(_currentEnergy);

    }

    public void TakeOffTenBullet(int amount) {

        _currentTenBulletMunicao = Mathf.Clamp(_currentTenBulletMunicao - amount, 0, MaxTenBulletMunicao);
        PlayerBulletObserver.TenBulletChanged(_currentTenBulletMunicao);
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



































