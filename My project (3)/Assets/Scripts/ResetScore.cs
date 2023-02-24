using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _gameManager.ZeroScore(0);
        _gameManager.ResetLives(5);
    }

    void Update()
    {
        
    }
}
