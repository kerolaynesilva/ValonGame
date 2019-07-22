using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class ButtonManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TimeManager timeManager;
    public GameObject[] buttons;//By giving the '[]' assingment to the GameObject var we have created an array! Arrays are one type of Data structure

    //Tempo de espera para começar a aparecer os personagens
    float randTime = .5f;
 
    //Tempo entre aparecimento dos personagens
    public float hideTime = 1.0f;

    //Tempo que apareceu o personagem
    public float timeAppeared = 0.0f;

    //Tempo que personagem foi clicado
    public float timeClicked = 0.0f;

    //Tempo de reacao
    public float reactionTime = 0.0f;

    // Inicializando o jogo
    void Start()
    {
        //Aqui foi realizada uma iteração através do array de 'buttons' e colocou-se cada um deles inativo no início do jogo.
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        //we also set a CoRoutine, which is a delayed event to start showing our random buttons which starts the game
        StartCoroutine(ShowButton());
    }    

    //Botões sendo ativados
    public void PressedBtn()
    {
        //allow the player to score as long as the game is still going
        if (timeManager.gameOver == false)
        {
            //Grab a reference to the object that we pressed so we can do some stuff with it

            GameObject myBtn = EventSystem.current.currentSelectedGameObject;
            if(myBtn != null)
            {                
                timeClicked = Time.time;  // Tempo de click sobre o personagem
                Debug.Log(timeClicked);
                ReactTime(timeClicked, timeAppeared);                
            }

            myBtn.GetComponentInChildren<Image>().color = Color.green;  //Sinaliza com verde, que o jogador acertou o alvo

            //add a point
            scoreManager.UpdateScore(1, true); // Adiciona a quantidade de captura de personagens
            
            //start a delayed timer aka a CoRoutine to hide the button again until the Next time it is chosen
            StartCoroutine(HitButton(myBtn));
        }

    }

    //this is on repeat, until the game is over
    public IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(randTime);

        //allow the coroutine to happen as long as the game is still going
        if (timeManager.gameOver == false)
        {
            //randomly pick a button in the index to show.  By using .Length it will count how many buttons are in our array, so it can change with out our help aka it's now dynamic
            int randBtn = Random.Range(0, buttons.Length);

            //we grab the button at the numbered postion "randBtn" in the "buttons[]" array and see if it is active
            if (buttons[randBtn].activeInHierarchy == false)//not active so let's show it
            {
                buttons[randBtn].SetActive(true);

                if (buttons[randBtn] != null) // Tempo em que aparece personagem na tela
                {
                    timeAppeared = Time.time;
                    Debug.Log(timeAppeared);
                }

                yield return new WaitForSeconds(10f);
            }
            //let's make the time random, for next time this coroutine is called
            randTime = Random.Range(2, 5f);

            //we need the coroutine to keep repeating to keep the game going, so we call it in itself.  
            StartCoroutine(ShowButton());

            //hide the button too after a delay, like in whack a mole
            StartCoroutine(HideButton(buttons[randBtn]));
        }

    }

    /// <summary>
    /// Hides the button after a delay from being Shown
    /// Called from "ShowButton" coroutine
    /// </summary>
    /// <returns>The button.</returns>
    /// <param name="myBtn">My button.</param>
    IEnumerator HideButton(GameObject myBtn)
    {
        yield return new WaitForSeconds(hideTime);

        //let's make sure it wasn't hit first because we don't want two coroutines on the same button
        if (myBtn.GetComponentInChildren<Image>().color == Color.white)
        {    //set to inactive so that it can get called again!
            myBtn.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Called when you hit a button, to reset it's state back to hidden and green
    /// Notice how we passed the game object thru the method! Now we have full access to the original button, but in a different method
    /// </summary>
    /// <returns>The button.</returns>
    /// <param name="myBtn">My button.</param>
	IEnumerator HitButton(GameObject myBtn)
    {
        yield return new WaitForSeconds(.5f);
        
        myBtn.GetComponentInChildren<Image>().color = Color.white;
        //set to inactive so that it can get called again!
        myBtn.gameObject.SetActive(false);
    }

    public void ReactTime(float timeClicked, float timeAppeared)
    {
        reactionTime = timeClicked - timeAppeared;
        CreateText(reactionTime);
        Debug.Log(reactionTime);    
        
    }

    public void CreateText(float reactionTime)  //Função para escrever aquivo texto com os tempos de reação do jogo
    {
        //Path of the file
        string path = Application.dataPath + "/ReactionTime.txt";
        //Content of the file  
        string content = "Time: " + reactionTime.ToString() + "s" + "\n";

        if (!File.Exists(path))
        {
            File.AppendAllText(path, "Reactions Times:\n");
        }
        
        System.IO.File.AppendAllText(path, content);
    }
}



    