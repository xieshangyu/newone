using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI4 : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "level4";
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

}
