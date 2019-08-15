using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreText;
    public static int Inquiries = 4;
    public static bool Win = false;
    public static string NextScene;
    public static int DelaySec;
    public RectTransform dialoguePanel;
    public RectTransform warrningPanel;

    public static IEnumerator DelayedChange()
    {
        yield return new WaitForSecondsRealtime(DelaySec);
        SceneManager.LoadScene(NextScene);
    }
    
    public void Update()
    {
        if ((Inquiries < 1) & (!Win) & !dialoguePanel.gameObject.activeInHierarchy)
        {
            warrningPanel.gameObject.SetActive(true);
            NextScene = "GuessWho";
            DelaySec = 5;
            StartCoroutine(DelayedChange());
        }

        scoreText.text = string.Concat("Remained Inquiries: ", Inquiries.ToString());
    }

    
}
