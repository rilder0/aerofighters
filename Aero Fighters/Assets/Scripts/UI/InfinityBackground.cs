using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBackground : MonoBehaviour
{

    public Renderer renderer;
    public float velocity;

    private Material material;
    private Vector2 offsetMaterial;
    void Start()
    {
        this.material = this.renderer.material;
        this.offsetMaterial = this.material.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        this.offsetMaterial.x += this.velocity * Time.deltaTime;
        this.material.SetTextureOffset("_MainTex", this.offsetMaterial);
    }
}
