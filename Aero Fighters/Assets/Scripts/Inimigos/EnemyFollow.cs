using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    private Transform WhoFollow;

    void Start()
    {
//        WhoFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
//        transform.position = Vector2.MoveTowards(transform.position, WhoFollow.position, speed * Time.deltaTime);
    }
}
