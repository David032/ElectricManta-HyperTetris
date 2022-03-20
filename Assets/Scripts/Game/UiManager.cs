using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ScoreValue;
    [SerializeField]
    TextMeshProUGUI HighscorValue;

    private void Start()
    {
        GameController.Instance.OnScoreChange.AddListener(UpdateScoreDisplay);
        HighscorValue.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    void UpdateScoreDisplay() 
    {
        ScoreValue.text = GameController.Instance.PlayerScore.ToString();
    }

}
