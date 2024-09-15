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
    public int maxHealth = 3;
    public int score;
    public int scoreTarget;
    public bool gamePause = false;

    [Header("# Game Object")]
    public GameObject overUI;
    public GameObject clearUI;
    public Spawner spawner;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject[] items;
    public GameObject youwin;

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
        spawner.GetComponent<Spawner>().isSpawning = false;
        items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items)
        {
            item.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        overUI.gameObject.SetActive(true);
        
    }

    public void GameClear()
    {
        gamePause = true;
        spawner.GetComponent<Spawner>().isSpawning = false;
        items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items)
        {
            item.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        clearUI.gameObject.SetActive(true);
        youwin.SetActive(true);
    }

    public void decreaseHealth() {
        health--;
        if (health == 0)
        {
            GameOver();
        }
    }

    public void updateScore(int addedScore) {
        score += addedScore;
        scoreText.text = "Score: " + score.ToString();

        if (score >= scoreTarget) {
            GameClear();
        }
    }
}