using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyUIController : MonoBehaviour
{
    private Slider energySlider;

    private void OnEnable() {

        PlayerObserverManeger.OnEnergyChanged += UpdateEnergy;
    }

    private void OnDisable() {

        PlayerObserverManeger.OnEnergyChanged -= UpdateEnergy;

    }

    private void Awake() {

        energySlider = GetComponent<Slider>();

    }


    private void UpdateEnergy(int value) {

        energySlider.value = value;
    }


}
