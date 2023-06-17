using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class StartScreen : MonoBehaviour
{
    public GameObject startPanel, countdownPanel;
    public PlayableDirector countdownAnim;

    private void Awake()
    {
        Time.timeScale = 0f;
    }


    public void StartCountdown()
    {
        startPanel.SetActive(false); 
        countdownPanel.SetActive(true);
        Time.timeScale = 1f;
        countdownAnim.Play();
        Invoke("Play", (float)countdownAnim.duration);

    }

    void Play()
    {
        countdownPanel.SetActive(false);
        this.GetComponent<Timer>().StartTimer();
    }

}
