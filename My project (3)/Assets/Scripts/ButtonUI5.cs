using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI5 : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "begin";
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

}
