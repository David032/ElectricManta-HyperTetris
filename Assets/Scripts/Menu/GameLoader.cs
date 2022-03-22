using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public void LoadGame() 
    {
        //Ideally this should async into a loading screen,
        //but there's so few assets this'll be fine
        SceneManager.LoadScene(1);
    }
}
