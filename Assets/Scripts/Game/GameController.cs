using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController:Cardinal.CardinalSingleton<GameController>
{
    [SerializeField]
    int Score = 0;
    [SerializeField]
    GameObject EndGameWindow;

    public Spawner Spawner;
    public Button LeftButton;
    public Button RightButton;
    public Button DownButton;
    public Button RotateButton;

    public int PlayerScore 
    {
        get 
        {
            return Score;
        }
        set 
        {
            Score += value;
            OnScoreChange.Invoke();
        }
    }

    public UnityEvent OnScoreChange;

    public void PlayAgain() 
    {
        int currentHighscore = PlayerPrefs.GetInt("HighScore");
        if (Score > currentHighscore)
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOverMessage() 
    {
        EndGameWindow.SetActive(true);
    }
}
