using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public AudioSource loseSource;
    public AudioClip loseClip;
    public AudioSource winSource;
    public AudioClip winClip;

    private void Start()
    {
        ScoreBoard.NextScene = "End";
    }

    public void Lose()
    {
        ScoreBoard.DelaySec = 2;
        ScoreBoard.Win = false;
        loseSource.clip = loseClip;
        loseSource.Play();
        StartCoroutine(ScoreBoard.DelayedChange());
    }

    public void Win()
    {
        ScoreBoard.DelaySec = 8;
        ScoreBoard.Win = true;
        winSource.clip = winClip;
        winSource.Play();
        StartCoroutine(ScoreBoard.DelayedChange());
    }
}
