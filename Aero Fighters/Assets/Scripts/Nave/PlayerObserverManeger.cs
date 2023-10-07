using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerObserverManeger
{

    public static Action<int> OnPointsChanged; //PlayerObserverManeger ficará sabendo que os pontos mudaram caso esse Action seja 
                                               //usado em qualquer outro código (quando o player derrotar um inimigo)
    public static void PointsChanged(int points) { //com a informação que os pontos mudaram, a classe usará esse método para atualizar
                                                   //os pontos na variavel de pontos, que podemos mostrar na GUI
        OnPointsChanged?.Invoke(points);
    }

    public static Action<int> OnEnergyChanged;

    public static void EnergyChanged(int energy) {

        OnEnergyChanged?.Invoke(energy);

    }
}

//a classe PlayerObserverManger é como se fosse um canal no YouTube. Pessoas podem fazer a ação de se inscrever nele. Quando alguém 
//se inscreve nesse canal, ele é avisado que ele tem um novo incrito por um Action. Em outras palavras, a classe PlayerObserverManger
//vai receber a informação que os pontos mudaram se uma ação de mudar os pontos (derrotar algum inimigo, por exemplo), e ele fica
//sabendo que os pontos mudaram por um Action
