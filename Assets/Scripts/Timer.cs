using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; 
    private float timeRemaining; 
    private bool isRunning = true; 

    public TextMeshProUGUI timerText;

    public GameObject endPanel;
    public TextMeshProUGUI finalScore;



    private void Start()
    {
        timeRemaining = totalTime; //Set total time.
    }

    private void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; //Reduce total time.
                UpdateTimerText();
            }
            else
            {               
                timeRemaining = 0f;
                UpdateTimerText();
                // Faça algo quando o tempo acabar, como exibir uma mensagem ou executar alguma ação

                finalScore.text = "Sua pontuação foi: "+ this.GetComponent<Score>().totalScore.ToString();
                endPanel.SetActive(true);  
            }
        }
    }

    private void UpdateTimerText()
    {
        // Converte o tempo restante em minutos e segundos formatados como string
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = "Tempo Restante: "+timeString; //Update timer in UI.
    }

    public void StartTimer()
    {
        timeRemaining = totalTime; //Set total time.
    }
}
