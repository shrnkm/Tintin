using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void ExitNow()
    {
        Application.Quit();
    }
    
    public void StartNow()
    {
        SceneManager.LoadScene("BoHaus");
    }

    public void ReStart()
    {
        ScoreBoard.Inquiries = 4;
        ScoreBoard.Win = false;
        SceneManager.LoadScene("Start");
    }
}