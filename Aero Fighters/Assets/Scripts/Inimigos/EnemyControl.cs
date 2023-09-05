using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //Gerais 
    private float TimeforAppear;

    //Obstacles
    public Obstacles Obstacle1Prefab;
    public Obstacles Obstacle2Prefab;
    private float timeAfterObstacles;
    //Caça Estelar
    public CaçaEstelar CaçaOriginal;
    private float timeAfterCaça;

    //Nave de Ataque
    public AttackShip AttackOriginal;
    private float timeAfterAttackShip;

    //Cruzador de batalha
    public BattleCruiser CruiserOriginal;
    private float timeAfterCruiser;

    //Nave Mãe
    public Boss BossOriginal;
    private float timeAfterBoss;

    public HpBoss HpBossPrefab;

    //Variáveis para instanciar escudo
    public EscudoColetavel escudoPrefab;
    private float TimeAfterEscudo;

    //Variáveis para instanciar power up do foguete
    public FogueteColetavel FogueteColetavelPreFab;
    private float TimeAfterFoguete;

    //Variáveis para instanciar power up do laser
    public LaserColetavel lasercoletavelprefab;
    private float TimeAfterLaser; //tempo pro laser aparecer
    





    void Start()
    {
        this.timeAfterObstacles = 0;
        this.TimeforAppear = 0; //contagem do tempo inicia com 0
        this.timeAfterCaça = 0;
        this.timeAfterAttackShip = 0;
        this.timeAfterBoss = 0;
        this.TimeAfterEscudo = 0;
        this.TimeAfterFoguete = 0;
        this.TimeAfterLaser = 0;
    }

    void Update()
    {
        //this.HpBossPrefab.gameObject.SetActive(false);
        CriarObstaculo1();
        CriarObstaculo2();
        CriarEscudo();
        CriarPowerupFoguete();
        CriarPowerupLaser();
        TimeforAppear += Time.deltaTime;
        if (this.TimeforAppear >= 10 && TimeforAppear <= 150)
        {
            CriarCaça();
            CriarAttackShip();
            CriarBattleCruiser();
            CriarBoss();
            //this.HpBossPrefab.gameObject.SetActive(true);
        }

        if (TimeforAppear >= 155)
        {
            CriarBoss();
        }
    }

    private void CriarCaça() {

        this.timeAfterCaça += Time.deltaTime;
        if (this.timeAfterCaça >= 8f)
        {
            this.timeAfterCaça = 0;
            //cada 5 segundo se cria um novo caça estelar

            Vector2 CaçaPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 CaçaPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float positionY = Random.Range(4,-3);
            
            Vector2 CaçaPosition = new Vector2(8, positionY);
            
            
            Instantiate(this.CaçaOriginal, CaçaPosition, Quaternion.identity);
        }
    }

    private void CriarAttackShip() {

        this.timeAfterAttackShip += Time.deltaTime;
        if (this.timeAfterAttackShip >= 10f)
        {
            this.timeAfterAttackShip = 0;
            //cada 5 segundo se cria um novo caça estelar

            Vector2 AttackShipPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 AttackshipPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float AttackShipPositionY = Random.Range(4,-3);
            
            Vector2 AttackShipPosition = new Vector2(8, AttackShipPositionY);
            
            Instantiate(this.AttackOriginal, AttackShipPosition, Quaternion.identity);
        }
    }

    private void CriarBattleCruiser() {

        this.timeAfterCruiser += Time.deltaTime;
        if (this.timeAfterCruiser >= 15f)
        {
            this.timeAfterCruiser = 0;
            //cada 5 segundo se cria um novo cruzador de batalha

            Vector2 CruiserPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 CruiserPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float CruiserPositionY = Random.Range(4,-3);
            
            Vector2 CruiserPosition = new Vector2(8, CruiserPositionY);
            
            Instantiate(this.CruiserOriginal, CruiserPosition, Quaternion.identity);
        }
    }

    private void CriarObstaculo1() {

        this.timeAfterObstacles += Time.deltaTime;
        if (this.timeAfterObstacles >= 8f)
        {
            this.timeAfterObstacles = 0;
            //cada 5 segundo se cria um novo cruzador de batalha

            Vector2 Obstacle1PositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 Obstacle1PositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float Obstacle1PositionY = Random.Range(3,-3);
            float Obstacle2PositionY = Random.Range(4,-3);
            
            Vector2 Obstacle1Position = new Vector2(8, Obstacle1PositionY);
            Vector2 Obstacle2Position = new Vector2(8, Obstacle2PositionY);
            
            Instantiate(this.Obstacle1Prefab, Obstacle1Position, Quaternion.identity);
        }
    }

    private void CriarObstaculo2() {

        this.timeAfterObstacles += Time.deltaTime;
        if (this.timeAfterObstacles >= 3f)
        {
            this.timeAfterObstacles = 0;
            //cada 5 segundo se cria um novo obstáculo

            Vector2 Obstacle2PositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 Obstacle2PositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float Obstacle2PositionY = Random.Range(4,-3);
            
            Vector2 Obstacle2Position = new Vector2(8, Obstacle2PositionY);
            
            Instantiate(this.Obstacle2Prefab, Obstacle2Position, Quaternion.identity);
        }
    }

    private void CriarBoss()
    {
        this.timeAfterBoss += Time.deltaTime;
        if (this.timeAfterBoss >= 10f)
        {
            this.timeAfterBoss = 0;
            //boss irá aparecer após 155s do jogo ser iniciado

            Vector2 BossPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 BossPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float BossPositionY = Random.Range(4,-3);
            
            Vector2 BossPosition = new Vector2(8, BossPositionY);
            
            Instantiate(this.BossOriginal, BossPosition, Quaternion.identity);
        }

    }

    private void CriarEscudo() 
    {
        this.TimeAfterEscudo += Time.deltaTime;

        if(this.TimeAfterEscudo >= 4) {

            this.TimeAfterEscudo = 0;

            Vector2 EscudoPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 EscudoPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float EscudoPositionY = Random.Range(4,-3);
            
            Vector2 EscudoPosition = new Vector2(8, EscudoPositionY);
            
            Instantiate(this.escudoPrefab, EscudoPosition, Quaternion.identity);
        }
    }

    private void CriarPowerupFoguete() 
    {
        this.TimeAfterFoguete += Time.deltaTime;

        if(this.TimeAfterFoguete >= 4) {

            this.TimeAfterFoguete = 0;

            Vector2 PwFoguetePositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 PwFoguetePositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float PwFoguetePositionY = Random.Range(4,-3);
            
            Vector2 PwFoguetePosition = new Vector2(8, PwFoguetePositionY);
            
            Instantiate(this.FogueteColetavelPreFab, PwFoguetePosition, Quaternion.identity);
        }
    }

    private void CriarPowerupLaser() 
    {
        this.TimeAfterLaser += Time.deltaTime;

        if(this.TimeAfterLaser >= 4) {

            this.TimeAfterLaser = 0;

            Vector2 PwLaserPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 PwLaserPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float PwLaserPositionY = Random.Range(4,-3);
            
            Vector2 PwLaserPosition = new Vector2(8, PwLaserPositionY);
            
            Instantiate(this.lasercoletavelprefab, PwLaserPosition, Quaternion.identity);
        }
    }









}

//esse codigo serve pra 
//timeAfter é uma variavel que guarda o intervalo de tempo entre a criação de inimigos, ou seja, o tempo descorrido depois da criação de um inimigo a fim de criar outro.
//se esse tempo for = 1s, a cada 1 segundo um inimigo vai ser criado
//this.timeAfter += Time.deltaTime; é basicamente dar a variavel timeAfter a noção de como tempo real está passando, para que ele tenha essas informações e crie inimigos 
//no tempo real. o tempo real é obtido atraves da classe time e o metodo delta time. o incremento na variavel se justifica porque os segundos vao passando e se somando.
//o metodo instantiate é um metodo que cria um novo objeto, e passando como parametro um objeto que já existe, ele vai duplicar

//como eu fiz pro inimigo surgir fora da câmera? eu criei duas posições: CaçaPositionMaximum, que é a posição que eu quero onde o inimigo surga e caçaposition, que é a posição original dele. 
//a ideia é que eu pegue essa nova posição e substitua os valores da posição original com ela, fazendo com que esses novos valores seja sua posição de fato. mas como eu pego essa posição fora
//da câmera? a referência que eu usei foi a câmera, atraves do metodo camera.main.viewporttoscreenpoint. peguei um game object vazio e coloquei ele na posição que eu queria que os inimigos fossem 
//criados, e passei os valores do eixo x e y nesse vector. no caçaposition eu faço isso de novo
//pra que esses inimigos começem a nascer fora da camera, eu preciso passar a posição que eu quero no instantiate, que é o método que tá gerando eles. quaternion.identity garante pra gente que esse
//gameobject nao ta sendo instanciado rotacionado
//como eu fiz pra que o inimigo fosse gerado em diferentes posições do eixo y? eu fiz com que o eixo Y (positionY) tivesse um valor aleatório entre 4 e -3, que são os valores máximo e mínimo, e alterei
//pra que esse valor aleatorio assuma realmente o valor de y: Vector2 CaçaPosition = new Vector2(8, positionY);

//pra instanciar mais de um inimigo, primeiramente separei a criação periódia de inimigos em funções: CriarCaça(), e por aí vai. Dentro dessas funções, dei um control c e control v no código base do
//caça estelar e mudei os nomes das variáveis. importante que a variavel que guarda a informação do tempo pra cada inimigo ser criado, não pode ser uma só. Tive que criar o time after pro caça, pra nave
//de ataque e entre outros.



































