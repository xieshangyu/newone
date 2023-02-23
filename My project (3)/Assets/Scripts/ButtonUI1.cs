using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI1 : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "tutorial";
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

}
