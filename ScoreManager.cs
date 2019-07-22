using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ScoreTypes // variáveis para armazenar os resultados do jogador
{
    PlayerScore,
    PlayerHits,
    PlayerMisses
} 

public class ScoreManager : MonoBehaviour
{

    public Text scoreLabel;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(ScoreTypes.PlayerHits.ToString(), 0);
        PlayerPrefs.SetInt(ScoreTypes.PlayerScore.ToString(), 0);
        PlayerPrefs.SetInt(ScoreTypes.PlayerMisses.ToString(), 0);
    }

    public void UpdateScore(int amount, bool addToScore)
    {
        if (addToScore == true)
        {
            score = PlayerPrefs.GetInt(ScoreTypes.PlayerScore.ToString());
            score += amount;
            PlayerPrefs.SetInt(ScoreTypes.PlayerScore.ToString(), score);

            int hits = PlayerPrefs.GetInt(ScoreTypes.PlayerHits.ToString());
            hits += 1;
            PlayerPrefs.SetInt(ScoreTypes.PlayerHits.ToString(), hits);

        }

        else
        {
            int misses = PlayerPrefs.GetInt(ScoreTypes.PlayerMisses.ToString());
            misses += 1;
            PlayerPrefs.SetInt(ScoreTypes.PlayerMisses.ToString(), misses);
        }
        scoreLabel.text = "Score: " + score;
    }
}
