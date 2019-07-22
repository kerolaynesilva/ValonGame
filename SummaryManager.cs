using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SummaryManager : MonoBehaviour
{
    public Text scoreTxt;
    public Text hitTxt;
    public Text missTxt;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "Score: " + PlayerPrefs.GetInt(ScoreTypes.PlayerScore.ToString());
        hitTxt.text = "Hits: " + PlayerPrefs.GetInt(ScoreTypes.PlayerHits.ToString());
        missTxt.text = "Misses: " + PlayerPrefs.GetInt(ScoreTypes.PlayerMisses.ToString());               
    }

    public void RestartPressed()
    {
       SceneManager.LoadSceneAsync(GameScenes.GameScene.ToString());
    }

    public void MenuPressed()
    {
        SceneManager.LoadSceneAsync(GameScenes.MenuScene.ToString());
    }
}
