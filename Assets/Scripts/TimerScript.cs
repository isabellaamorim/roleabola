using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private int seconds;

    float elapsedTime;

        void Update()
    {
        elapsedTime += Time.deltaTime;
        seconds = Mathf.FloorToInt(elapsedTime % 60); 

        timerText.text = "Tempo (s): " + seconds.ToString();

        if (seconds >= 35)
        {
            GameOver();
        }

        if (seconds == 32)
        {
            timerText.color = Color.red;
        }
    }

    public void saveTime()
    {
        PlayerPrefs.SetInt("Time", seconds);
        PlayerPrefs.Save();
    }

    public void GameOver()
    {
        saveTime();
        SceneManager.LoadScene("GameOver");
    }
}
