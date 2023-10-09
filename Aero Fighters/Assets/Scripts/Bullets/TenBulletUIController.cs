using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TenBulletUIController : MonoBehaviour
{
    
    private Text TenBulletText;

    private void OnEnable() {

        PlayerBulletObserver.OnTenBulletChanged += UpdateTenBullets;

    }

    private void OnDisable() {

        PlayerBulletObserver.OnTenBulletChanged -= UpdateTenBullets;
    }

    private void Awake() {

        TenBulletText = GetComponent<Text>();
    }

    private void UpdateTenBullets(int value) {

        TenBulletText.text = value.ToString();

    }
}
