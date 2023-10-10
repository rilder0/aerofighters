using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public NaveMove player;
    public GameObject posicao;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform);
        }
        else
            Destroy(gameObject);

    }

    private void Start()
    {
        LoadScene("MainMenu");

    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CarregarInterface()
    
    
    {
        SceneManager.LoadScene("GUI");

        SceneManager.LoadSceneAsync("LevelOne", LoadSceneMode.Additive).completed += operation =>
        {
            posicao = GameObject.FindWithTag("posicao");
            Vector2 ps = posicao.transform.position;


            Instantiate(player, ps, player.transform.rotation);

        };
    }
}
