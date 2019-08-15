using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public AudioSource failSourceVoice;
    public AudioClip failClipVoice;
    public AudioSource failSourceAww;
    public AudioClip failClipAww;
    public AudioSource winSource;
    public AudioClip winClip;
    public RectTransform inspectPanel;
    public GameObject theBlue;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Y) & inspectPanel.gameObject.activeInHierarchy)
        {
            if (inspectPanel.gameObject.activeInHierarchy)
            {
                inspectPanel.gameObject.SetActive(false);
            }
            
            if (ObjectScript.ObjectName == "Desk")
            {
                ScoreBoard.Inquiries--;
                theBlue.SetActive(true);
                ScoreBoard.DelaySec = 8;
                ScoreBoard.Win = true;
                ScoreBoard.NextScene = "End";
                winSource.clip = winClip;
                winSource.Play();
                StartCoroutine(ScoreBoard.DelayedChange());
            }
            else
            {
                failSourceVoice.clip = failClipVoice;
                failSourceVoice.Play();
                failSourceAww.clip = failClipAww;
                failSourceAww.Play();
                ScoreBoard.Inquiries--;
            }

        }

        if (Input.GetKey(KeyCode.N))
        {
            inspectPanel.gameObject.SetActive(false);
        }
    }
    
}
