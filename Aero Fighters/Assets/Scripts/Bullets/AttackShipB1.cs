using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShipB1 : MonoBehaviour
{
    public Rigidbody2D Rigidbody2DBullet;
    public float velocityY;

    void Start()
    {
        this.Rigidbody2DBullet.velocity = new Vector2(0, velocityY * 5);
    }

    void Update()
    {
        
    }
}
