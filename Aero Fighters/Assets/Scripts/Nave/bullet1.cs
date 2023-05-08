using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float bullet1velocityX;
    void Start()
    {
        this.rigidbody.velocity = new Vector2(bullet1velocityX, 0);
    }
}
