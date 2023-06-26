using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCruiser : MonoBehaviour
{
    
    public Rigidbody2D CruiserRigidbody;
    public float velocidadeMin;
    public float velocidadeMax;
    private float velocidadeY;

    private int BattcleCruiserHealth;

    void Start()
    {
        this.velocidadeY = Random.Range(this.velocidadeMin, this.velocidadeMax);
        this.BattcleCruiserHealth = 100;
    }

    void Update()
    {
        this.CruiserRigidbody.velocity = new Vector2(-this.velocidadeY, 0);
    }
    
    public int HealthBattcleCruiser
    {
        get
        {
            return this.BattcleCruiserHealth;
        }
        set
        {
            this.BattcleCruiserHealth = value;
        }
    }

    
    public void DestroyBattleCruiser(bool isover)
    {
        if (isover)
        {
            PointsControlr.Pontuation += 15;
        }

        if (BattcleCruiserHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
