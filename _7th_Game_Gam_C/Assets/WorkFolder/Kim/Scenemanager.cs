using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenemanager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        SceneManager.LoadScene("SceneLoading");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

}