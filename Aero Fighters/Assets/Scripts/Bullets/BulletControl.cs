using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour
{
    public Text MunicaoB1Text;
    public Text MunicaoB2Text;
    public Text MunicaoB3Text;


    private static int MunicaoFoguete = 10;
    private static int MunicaoLaser = 15;
    private static int PorcentagemLaser = MunicaoLaser / 15;
    private static int MunicaoRapido = 50000000; 

    void Start()
    {
        
    }

    void Update()
    {
        MunicaoB1Text.text = MunicaoFoguete.ToString();
        MunicaoB2Text.text = MunicaoLaser.ToString();
        MunicaoB3Text.text = "∞"; //munição infinita
    }

    public static int MuniçãoTiroFoguete 
    {
        get {
            return MunicaoFoguete;
        }
        set {
            MunicaoFoguete = value;
            if(MunicaoFoguete < 0) {
                MunicaoFoguete = 0;
            }
        }

    }

    public static int MuniçãoTiroLaser 
    {
        get {
            return MunicaoLaser;
        }
        set {
            MunicaoLaser = value;
            if(MunicaoLaser < 0) {
                MunicaoLaser = 0;
            }
        }

    }

    public static int MuniçãoTiroRapido 
    {
        get {
            return MunicaoRapido;
        }
        set {
            MunicaoRapido = value;
            if(MunicaoRapido < 0) {
                MunicaoRapido = 0;
            }
        }

    }
}
