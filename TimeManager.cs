using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Text timeLabel; // acesso ao texto de tempo
    public Text gameOverLabel; // aviso de fim de jogo
    float maxTime = 60; // tempo máximo de jogo igual a 60s

    [HideInInspector]
    public bool gameOver = false; 

    private void Update()
    {
        // contagem regressiva do tempo de jogo 
        maxTime -= Time.deltaTime; // a operação -= faz a contagem regressiva
        int seconds = Mathf.RoundToInt(maxTime % 60f);

        if(seconds >= 0)
        {
            timeLabel.text = "Time: " + seconds.ToString("00");
        }
        else
        {
            if(gameOver == false)
            {
                gameOver = true; // jogo acabou, variável gameOver se tornará verdadeira
                gameOverLabel.gameObject.SetActive(true);                
                StartCoroutine(ChangeScene()); // depois de um delay, troca a cena
            }            
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2); // depois de um delay de 2 segundos do fim do jogo, a cena é trocada pela pontuação do jogador
        SceneManager.LoadSceneAsync(GameScenes.ScoreScene.ToString());
    }
}
