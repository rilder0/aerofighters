using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Rigidbody2D BossRigid;

    public float velocidadeMin;
    public float velocidadeMax;
    private float velocidadeY;
        
    private int healthAttackShip;
        

    void Start()
    { 
        this.velocidadeY = Random.Range(this.velocidadeMin, this.velocidadeMax);
    }

    void Update()
    { 
        this.BossRigid.velocity = new Vector2(-this.velocidadeY, 0);

    }
}
