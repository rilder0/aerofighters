using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShip : MonoBehaviour
{
    public Rigidbody2D Attackshiprigidbody;
    public float velocidadeMin;
    public float velocidadeMax;

    private float velocidadeY;
    void Start()
    {
        this.velocidadeY = Random.Range(this.velocidadeMin, this.velocidadeMax);
    }

    void Update()
    {
        this.Attackshiprigidbody.velocity = new Vector2(-this.velocidadeY, 0);
    }
}
