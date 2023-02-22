using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 3;
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
        livesUI.text = "LIVES " + lives;
    }

    public void AddScore(int points) {
        score += points;
        scoreUI.text = "SCORE: " + score;
    }

    public void AddLife(int life) {
        lives += life;
        livesUI.text = "LIVES " + lives;
    }

    public void Update()
    {
    // !UNITY_WEBGL;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
