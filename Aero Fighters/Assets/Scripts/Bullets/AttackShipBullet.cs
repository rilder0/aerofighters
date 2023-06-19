using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShipBullet : MonoBehaviour
{
    public Rigidbody2D Rigidbody2DBullet;
    public float velocityX; //velocidade no eixo X
    public float velocityY;
    
    void Start()
    {
        this.Rigidbody2DBullet.velocity = new Vector2(-velocityX * 5, 0);
    }

    void Update()
    {
        
    }
}
