using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckShipB3 : MonoBehaviour
{
    public Rigidbody2D Rigidbody2DBullet;
    public float velocityY;

    void Start()
    {
        this.Rigidbody2DBullet.velocity = new Vector3(0, velocityY * 5);
    }
    void Update()
    {
        
    }
}
