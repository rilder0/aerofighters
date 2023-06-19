using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShip : MonoBehaviour
{
    public Rigidbody2D Attackshiprigidbody;

    public float velocidadeMin;
    public float velocidadeMax;
    private float velocidadeY;

    private int healthAttackShip;
    
    public AttackShipBullet PrefabBullet;
    public AttackShipB1 PrefabBullet1;
    public AttackShipB2 PrefabBullet2;
    public AttckShipB3 PrefabBullet3;
    
    
    private float BulletAttackShipTime; //tempo entre criação de balas

    void Start()
    {
        this.BulletAttackShipTime = 0;  //a conatagem de tempo inicia com 0
        this.healthAttackShip = 50;
        this.velocidadeY = Random.Range(this.velocidadeMin, this.velocidadeMax);
    }

    void Update()
    {
        this.BulletAttackShipTime += Time.deltaTime;
        if (this.BulletAttackShipTime >= 1f)
        {
            this.BulletAttackShipTime = 0;
            AttackShipAtirar();
        }
        
        //Debug.Log("Vida do Attack Ship = " + healthAttackShip);
        this.Attackshiprigidbody.velocity = new Vector2(-this.velocidadeY, 0);
    }

    public void DestroyAttackShip(bool isover)
    {
        if (isover) //quando a colisão realmente acontecer é que os pontos serão computados.
        {
            PointsControlr.Pontuation += 5;
        }
        if(healthAttackShip <= 0) { //quando a vida iguala a zero, o gameobject que esse script tá associado (sttackship) será destruído
           Destroy(this.gameObject);
        }
    }
    public int HealthAttackShip
    {
        get
        {
            return this.healthAttackShip;
        }
        set
        {
            this.healthAttackShip = value;
        }
    }

    private void AttackShipAtirar() //método pro attackship instanciar um tiro
    {
        Instantiate(this.PrefabBullet, this.transform.position, Quaternion.identity);
        Instantiate(this.PrefabBullet1, this.transform.position, Quaternion.Euler(0,0,10));
        Instantiate(this.PrefabBullet2, this.transform.position, Quaternion.Euler(0,0,-10));
        Instantiate(this.PrefabBullet3, this.transform.position, Quaternion.Euler(0,0,5));
    }
}

//a movimentação do attackship eu copiei alguns códigos do caça estelar, como a velocida máxima e mínima. porém, o 
//attackship é uma nave mais sofisticada e não era destruída com apenas um tiro como o caça estelar, ou seja, o attack
//ship precisava de vida, e a cada colisão entre o tiro do jogador e o attackship, uma quantidade x de vida era retirada
//e quando essa vida chegava a zero, o attackship era destruído. primeiro, eu criei o HealthAttackShip através dos métodos
//GET e SET, igual ao player. um erro que tava acontecendo, era que quando o attackship colidia com a bala, somava ponto
//pra resolver isso, precisei criar um método pra controlar quando essa pontuação vai ser computada ou não, que é o método
//DestroyAttackShip. Agora, eu tenho que configurar as colisões, tipo: Quando a bala colidiir com um gameobject com a tag
//"attackship", 5 vidas eram subtraídas e eu chamaria o método DestroyAttackShip só quando a vida do attackship = 0

