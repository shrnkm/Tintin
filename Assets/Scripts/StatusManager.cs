using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public AudioSource lostThemeSource;
    public AudioClip lostThemeClip;
    public AudioSource wonThemeSource;
    public AudioClip wonThemeClip;
    public GameObject theBlue;
    public GameObject theRed;
    public Text theStatusText;


    private void Start()
    {
        if (ScoreBoard.Win)
        {
            theStatusText.text = "You Won!";
            wonThemeSource.clip = wonThemeClip;
            wonThemeSource.Play();
            theBlue.SetActive(true);
        }

        else
        {
            theStatusText.text = "You Lost!";
            lostThemeSource.clip = lostThemeClip;
            lostThemeSource.Play();
            theRed.SetActive(true);
        }
    }
}
