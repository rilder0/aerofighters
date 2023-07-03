using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBoss : MonoBehaviour
{
    private float TimeforAppear;
    void Start()
    {
        this.TimeforAppear = 0f;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        this.TimeforAppear += Time.deltaTime;
        if(this.TimeforAppear >= 10f)
        {
            this.gameObject.SetActive(true);
        }
    }
}
