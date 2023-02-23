using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI3 : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "MediumLevel";
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

}
