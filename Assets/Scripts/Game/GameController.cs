using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController:Cardinal.CardinalSingleton<GameController>
{
    [SerializeField]
    int Score = 0;
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

}
