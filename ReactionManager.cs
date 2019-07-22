using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class ReactionManager : MonoBehaviour
{
    string path = "C:/Users/samsung/Desktop/ProjetoIHMS/Assets/ReactionTime.txt";
    public Text reactTxt;
    
    void Start()
    {
        reactTxt.text = File.ReadAllText(path);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(GameScenes.MenuScene.ToString()); // Retorna ao menu
    }
}