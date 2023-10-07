using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointsUIController : MonoBehaviour
{

    private TMP_Text pointsText;

    private void OnEnable() {

        PlayerObserverManeger.OnEnergyChanged += UpdatePoints;
    }

    private void OnDisable() {

        PlayerObserverManeger.OnPointsChanged -= UpdatePoints;

    }

    private void Awake() {

        pointsText = GetComponent<TMP_Text>();

    }

    private void UpdatePoints(int value) {

        pointsText.text = value.ToString();

        
    }

}
