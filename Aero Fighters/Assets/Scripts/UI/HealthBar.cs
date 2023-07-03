using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    
    public GameObject[] GreenBars;  //lista pra colocar as barrinhas verdes. cada uma delas vai ter um indice0
    
    public void ShowLifes(int healths) {
        for(int i = 0; i < this.GreenBars.Length; i++) {
            if (i < healths) {
                this.GreenBars[i].SetActive(true);
            }
            else {
                this.GreenBars[i].SetActive(false);
            }
        }

    }
}


