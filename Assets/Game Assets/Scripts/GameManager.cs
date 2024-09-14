using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    [Header("# Player Info")]
    public int health;
    public int maxHealth = 5;
    public int score;
    public bool gamePause = false;

    [Header("# Game Object")]
    public GameObject overUI;
    public GameObject clearUI;

    private void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health == 0)
        {
            GameOver();
        }
            

    }

    public void GameOver()
    {
        gamePause = true;
        Time.timeScale = 0f;
        overUI.gameObject.SetActive(true);
    }

    public void GameClear()
    {
        gamePause = true;
        Time.timeScale = 0f;
        clearUI.gameObject.SetActive(true);
    }
}
