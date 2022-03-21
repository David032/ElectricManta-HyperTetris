using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public void LoadGame() 
    {
        //Quick and dirty load
        SceneManager.LoadScene(1);
    }
}
