using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 5;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;

    private void Awake() {
        if (GameObject.FindObjectsOfType<GameManager>().Length > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }        
    }

    private void Start() {
        scoreUI.text = "SCORE: " + score;
        livesUI.text = "LIVES: " + lives;
    }

    public void AddScore(int points) {
        score += points;
        scoreUI.text = "SCORE: " + score;
    }

    public void AddLife(int life) {
        lives += life;
        livesUI.text = "LIVES: " + lives;
    }

    public void DeleteLife(int life) {
        lives -= life;
        livesUI.text = "LIVES: " + lives;
        if (lives <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ZeroScore(int zero) {
        score = zero;
        scoreUI.text = "SCORE: " + zero;
    }

    public void ResetLives(int life) {
        lives = life;
        scoreUI.text = "SCORE: " + lives;
    }

    public void Update()
    {
        if (scoreUI == null) {
            scoreUI = GameObject.FindGameObjectWithTag("ScoreUI").GetComponent<TextMeshProUGUI>();
            scoreUI.text = "SCORE: " + score;
        }
        if (livesUI == null) {
            livesUI = GameObject.FindGameObjectWithTag("LivesUI").GetComponent<TextMeshProUGUI>();
            livesUI.text = "LIVES: " + lives;
        }

    // !UNITY_WEBGL;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
