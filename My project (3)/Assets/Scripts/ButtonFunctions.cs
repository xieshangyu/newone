using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void LoadEasyLevel() {
        SceneManager.LoadScene("EasyLevel");
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void LoadTutorial() {
        SceneManager.LoadScene("Tutorial");
    }

}
