using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PorcentBulletUIController : MonoBehaviour
{

    private Text PorcentBulletText;

    private void OnEnable() {

        PlayerBulletObserver.OnPorcentBulletChanged += UpdatePorcentBullets;
    }

    private void OnDisable() {

        PlayerBulletObserver.OnPorcentBulletChanged -= UpdatePorcentBullets;
    }


    private void Awake() {

        PorcentBulletText = GetComponent<Text>();
    }



    private void UpdatePorcentBullets(int value) {

        PorcentBulletText.text = value.ToString();

    }



}
