using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController: MonoBehaviour
{
    [SerializeField]
    static int Score = 0;

    public static int GetScore() { return Score; }
    public static void IncreaseScore(int value) { Score += value; }

}
