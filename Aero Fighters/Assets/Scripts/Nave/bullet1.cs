using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class bullet1 : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float bullet1velocityX;
    void Start()
    {
        this.rigidbody.velocity = new Vector2(bullet1velocityX, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CaçaEstelar"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

//o que o metodo ontriggerenter2d faz? basicamente é um metodo que guarda a informação do primeiro instante da colisão, e ele guarda isso dentro de uma variavel collision do tipo collider2d
// como podemos fazer que, a partir do primeiro instante que a colisao ocorrer, ambos o tiro e o caçaestelar sejam destruidos? pra gente especificar quem sera destruido, temos que colocar tags 
//nos prefabs, pois a partir do metodo compare tag, o metodo destroy podera identificar quem esta com essa tag e destruilo, ou seja, quando a bala entrar na colisao com o inimigo, o objeto que a 
//bala colidiu, ou seja, o proprio inimigo, será destruido, bem como a prória bala;




























