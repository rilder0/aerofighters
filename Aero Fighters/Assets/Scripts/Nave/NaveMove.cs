using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.velocidadeMovimento);
        float velocidadeY = (vertical * this.velocidadeMovimento);
        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY);
        
    }
}
