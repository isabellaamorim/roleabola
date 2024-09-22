using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerButtonWin : MonoBehaviour
{
    public TextMeshProUGUI timerTextFinal;

    public void Start()
    {
        int time = PlayerPrefs.GetInt("Time");
        timerTextFinal.text = "Tempo de jogo: " + time.ToString() + " segundos";
    }
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
