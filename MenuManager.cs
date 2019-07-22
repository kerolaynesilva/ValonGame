using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{   
      
    public void StartPressed()
    {
        SceneManager.LoadSceneAsync(GameScenes.GameScene.ToString());
    }

    public void ResultsPressed()
    {
        SceneManager.LoadSceneAsync(GameScenes.ReactionScene.ToString());
    }
    public void exitGame()
    {
        Application.Quit();
    }
}

