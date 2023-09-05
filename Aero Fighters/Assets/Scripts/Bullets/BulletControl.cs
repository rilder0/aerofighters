using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour
{
    public Text MunicaoB1Text;
    public Text MunicaoB2Text;
    public Text MunicaoB3Text;


    private static int MunicaoFogueteAtual = 10;
    private static int MunicaoFogueteMax = 10;
    private static int MunicaoLaserAtual = 15;
    private static int MunicaoLaserMax = 15;
    private static int MunicaoRapido = 50000000; 

    void Start()
    {
        
    }

    void Update()
    {
        MunicaoB1Text.text = MunicaoFogueteAtual.ToString();
        PorcentagemAtualizada(MunicaoLaserAtual, MunicaoLaserMax, MunicaoB2Text);
        MunicaoB3Text.text = "∞"; //munição infinita
    }

    public static int MuniçãoTiroFoguete 
    {
        get {
            return MunicaoFogueteAtual;
        }
        set {
            MunicaoFogueteAtual = value;
            if(MunicaoFogueteAtual < 0) {
                MunicaoFogueteAtual = 0;
            }
        }

    }

    public static int MuniçãoTiroFogueteMax {

        get {
            return MunicaoFogueteMax;
        }
        set {
            MunicaoFogueteMax = value;
        }
    }

    public static int MuniçãoTiroLaserMax {

        get {
            return MunicaoLaserMax;
        }
        set {
            MunicaoLaserMax = value;
        }
    }










    public static int MuniçãoTiroLaser 
    {
        get {
            return MunicaoLaserAtual;
        }
        set {
            MunicaoLaserAtual = value;
            if(MunicaoLaserAtual < 0) {
                MunicaoLaserAtual = 0;
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

    private void PorcentagemAtualizada (int QuantidadeAtualMunicao, int QuantidadeMaxMunicao, Text textoporcentagem) {

        float porcentagem = (QuantidadeAtualMunicao / (float)QuantidadeMaxMunicao) * 100;
        int PorcentagemInteira = Mathf.FloorToInt(porcentagem); //Arrenda pro valor inteiro + próximo
        textoporcentagem.text = PorcentagemInteira.ToString() + " %";

    }
}
