using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningGame : MonoBehaviour
{

    public Text PointsText;
    public Text HealthText;
    
    void Update()
    {
        this.PointsText.text = PointsControlr.Pontuation.ToString();
 //       this.HealthText.text = NaveMove.Health.ToString();
    }
}

//esse script controla coisas que estao acontecendo no jogo enquanto ele roda. uma dessas coisas é atualizar os pontos. 
//criei uma variavel do tipo text e no update, chamei essa variavel e acessei o atributo texto dela, e dentro desse texto
//eu coloquei pra ser substituito pelos pontos, e converti pra string pra tudo isso ser possivel





















