using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShipBullet : MonoBehaviour
{
    public Rigidbody2D Rigidbody2DBullet;
    public float velocityX; //velocidade no eixo X
    
    void Start()
    {
        this.Rigidbody2DBullet.velocity = new Vector2(-velocityX * velocityX, 0);
    }

    void Update()
    {
        
    }
}
