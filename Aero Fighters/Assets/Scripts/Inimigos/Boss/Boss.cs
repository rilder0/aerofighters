using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Rigidbody2D BossRigid;

    public float velocidadeMin;
    public float velocidadeMax;
    private float velocidadeY;
        
    private int healthAttackShip;
    
    //Variáveis para a barra de vida
    public Slider HealthBarBoss;
    public int BossHealthMax = 30;
    public int BossHealthAtual = 30;


    void Start()
    {
        BossHealthAtual = BossHealthMax;
        this.velocidadeY = Random.Range(this.velocidadeMin, this.velocidadeMax);
    }

    void Update()
    { 
        this.BossRigid.velocity = new Vector2(-this.velocidadeY, 0);
        HealthBarBoss.value = BossHealthAtual;

        if (BossHealthAtual <= 0)
        {
            BossHealthAtual = 0;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet1"))
        {
            BossHealthAtual--;
        }
        
        if (collision.CompareTag("bullet2"))
        {
            BossHealthAtual--;
        }

        if (collision.CompareTag("bullet3"))
        {
            BossHealthAtual--;
        }

    }
}
