using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    [SerializeField] private int level;

    private void Start()
    {
        Time.timeScale = 1f;
        health = maxHealth;
    }

    void Update()
    {
        
            

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

    public void decreaseHealth() {
        health--;
        healthText.text = "Health: " + health.ToString();
        if (health == 0)
        {
            GameOver();
        }
    }

    public void updateScore(int addedScore) {
        score += addedScore;
        scoreText.text = "Score: " + score.ToString();
    }
}
