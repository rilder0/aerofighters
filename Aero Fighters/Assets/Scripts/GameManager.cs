using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;


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

        SceneManager.LoadScene("LevelOne", LoadSceneMode.Additive);
    }
}
