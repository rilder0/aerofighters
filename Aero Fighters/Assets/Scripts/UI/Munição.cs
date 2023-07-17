using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Munição : MonoBehaviour
{
    public int muniçãotirosimples;
    public bool estaatirando;

    public Text Munição1;
    void Start()
    {
        
    }

    void Update()
    {
        //Munição1.text = muniçãotirosimples.ToString("∞");
        if (Input.GetKey(KeyCode.Space) && !estaatirando && muniçãotirosimples > 0)
        {
            estaatirando = true;
            muniçãotirosimples--;
            estaatirando = false;
        }
        Debug.Log("Munição = " + muniçãotirosimples);
    }
}
