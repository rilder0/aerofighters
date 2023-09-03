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
    private static int MunicaoLaserAtual = 15;
    private static int MunicaoLaserMax = 15;
    private static int MunicaoRapido = 50000000; 

    void Start()
    {
        
    }

    void Update()
    {
        MunicaoB1Text.text = MunicaoFoguete.ToString();
        PorcentagemAtualizada(MunicaoLaserAtual, MunicaoLaserMax, MunicaoB2Text);
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
