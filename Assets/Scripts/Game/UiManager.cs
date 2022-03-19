using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ScoreValue;

    private void Start()
    {
        GameController.Instance.OnScoreChange.AddListener(UpdateScoreDisplay);
    }

    void UpdateScoreDisplay() 
    {
        ScoreValue.text = GameController.Instance.PlayerScore.ToString();
    }

}
