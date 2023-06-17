using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class Score : MonoBehaviour
{
    public int totalScore = 0;
    public TextMeshProUGUI scoreText;
    public int scoreCorrectOrder = 100, scoreCorrectIngredients = 50, scoreIncorrect = 100;


    // Start is called before the first frame update
    void Start()
    {
        updateScore();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addScore(bool correctOrder)
    {
        if(correctOrder)
        {           
            totalScore += scoreCorrectOrder;            
        }

        else
        {
            //scoreAnim.Play();
            totalScore += scoreCorrectIngredients;            
        }
       
        updateScore();
    }

    public void removeScore() 
    {
        totalScore -= scoreIncorrect;
        //scoreAnim.Play();
        updateScore();
        
    }

    public void updateScore()
    {
        scoreText.text = "Pontuação: " + totalScore;
    }

    
}
