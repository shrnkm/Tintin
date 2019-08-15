using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueWithRy : MonoBehaviour
{

    public Text preTintin;
    public Text RyText;
    public Text Option1Text;
    public Text Option2Text;
    public RectTransform dialougePanel;
    private int _treeLevel;
    public Boolean checkBool = true;
    private Dictionary<int, List<string>> treeDic;

    public void Start()
    {
        List<string> dialogueList = new List<string>();
        treeDic = new Dictionary<int, List<string>>();

        dialogueList.Add("Hi, Ms. Ry! Mind if I ask you a couple of questions?");
        dialogueList.Add("Ry: Sure, how can I help you son?");
        treeDic.Add(0, dialogueList);
        dialogueList.Add("When did you left the Diamondhaus?");
        dialogueList.Add("Ry: Around 9:30 pm.");
        treeDic.Add(1, dialogueList.GetRange(2, 2));
        dialogueList.Add("Did Bo steal The Blue?");
        dialogueList.Add("Ry: No, of course not!");
        treeDic.Add(2, dialogueList.GetRange(4, 2));
        dialogueList.Add("How were you informed of The Blue being stolen?");
        dialogueList.Add("Ry: I heard about it on the Morning News.");
        treeDic.Add(11, dialogueList.GetRange(6, 2));
        treeDic.Add(122, dialogueList.GetRange(6, 2));
        dialogueList.Add("Where did you go afterwards?");
        dialogueList.Add("Ry: I got back home.");
        treeDic.Add(12, dialogueList.GetRange(8, 2));
        dialogueList.Add("Did you talk about it with anyone else?");
        dialogueList.Add("Ry: Just with my cat.");
        treeDic.Add(111, dialogueList.GetRange(10, 2));
        dialogueList.Add("Do you have any special skill or interest in jewelry?");
        dialogueList.Add("Ry: Yes, I used to work in a jewelry store.");
        treeDic.Add(112, dialogueList.GetRange(12, 2));
        dialogueList.Add("Have you been alone at home, since last night?");
        dialogueList.Add("Ry: No I live with my cat.");
        treeDic.Add(121, dialogueList.GetRange(14, 2));
        dialogueList.Add("Thank you very much, ma'am! Have a good day!");
        dialogueList.Add("I gotta go! I found out who stole The Blue!");
        treeDic.Add(20, dialogueList.GetRange(16, 2));
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            preTintin.text = ("Wanna talk with Ry?");
            RyText.text = "";
            Option1Text.text = "Yes";
            Option2Text.text = "No";
            _treeLevel = 0;
            dialougePanel.gameObject.SetActive(true);
        }
    }

    public void DialogueManager()
    {
        preTintin.text = string.Concat("Tintin: ", treeDic[_treeLevel][0]);
        RyText.text = treeDic[_treeLevel][1];
        _treeLevel = _treeLevel * 10 + 1;
        Option1Text.text = treeDic[_treeLevel][0];
        Option2Text.text = treeDic[_treeLevel+1][0];
    }

    public void DialogueManagerEnd()
    {
        preTintin.text = string.Concat("Tintin: ", treeDic[_treeLevel][0]);
        RyText.text = treeDic[_treeLevel][1];
        _treeLevel = 20;
        Option1Text.text = treeDic[_treeLevel][0];
        Option2Text.text = treeDic[_treeLevel][1];
    }

    public void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Keypad1)) | (Input.GetKeyUp(KeyCode.Alpha1)) | (Input.GetKeyUp(KeyCode.Keypad2)) |
            (Input.GetKeyUp(KeyCode.Alpha2)))
        {
            checkBool = true;
        }
        if (dialougePanel.gameObject.activeInHierarchy & checkBool)
        {
            checkBool = false;

            switch (_treeLevel)
            {
                case 0:
                    if ((Input.GetKeyUp(KeyCode.Keypad1)) | (Input.GetKeyUp(KeyCode.Alpha1)))
                    {
                        ScoreBoard.Inquiries--;
                        DialogueManager();
                    }
                    if ((Input.GetKeyUp(KeyCode.Keypad2)) | (Input.GetKeyUp(KeyCode.Alpha2)))
                    {
                        dialougePanel.gameObject.SetActive(false);
                    }
                    break;

                case 1:
                    if ((Input.GetKeyUp(KeyCode.Keypad1)) | (Input.GetKeyUp(KeyCode.Alpha1)))
                    {
                        DialogueManager();
                    }
                    if ((Input.GetKeyUp(KeyCode.Keypad2)) | (Input.GetKeyUp(KeyCode.Alpha2)))
                    {
                        _treeLevel++;
                        DialogueManagerEnd();
                    }
                    break;

                case 11:
                    if ((Input.GetKeyUp(KeyCode.Keypad1)) | (Input.GetKeyUp(KeyCode.Alpha1)))
                    {
                        DialogueManager();
                    }
                    if ((Input.GetKeyUp(KeyCode.Keypad2)) | (Input.GetKeyUp(KeyCode.Alpha2)))
                    {
                        _treeLevel++;
                        DialogueManager();
                    }
                    break;

                case 111:
                    if ((Input.GetKeyUp(KeyCode.Keypad1)) | (Input.GetKeyUp(KeyCode.Alpha1)))
                    {
                        DialogueManagerEnd();
                    }
                    if ((Input.GetKeyUp(KeyCode.Keypad2)) | (Input.GetKeyUp(KeyCode.Alpha2)))
                    {
                        _treeLevel++;
                        DialogueManagerEnd();
                    }
                    break;
                
                case 121:
                    if ((Input.GetKeyUp(KeyCode.Keypad1)) | (Input.GetKeyUp(KeyCode.Alpha1)))
                    {
                        DialogueManagerEnd();
                    }
                    if ((Input.GetKeyUp(KeyCode.Keypad2)) | (Input.GetKeyUp(KeyCode.Alpha2)))
                    {
                        _treeLevel++;
                        DialogueManagerEnd();
                    }
                    break;
                
                case 20:
                    if ((Input.GetKeyUp(KeyCode.Keypad1)) | (Input.GetKeyUp(KeyCode.Alpha1)))
                    {
                        dialougePanel.gameObject.SetActive(false);
                    }
                    if ((Input.GetKeyUp(KeyCode.Keypad2)) | (Input.GetKeyUp(KeyCode.Alpha2)))
                    {
                        SceneManager.LoadScene("GuessWho");
                    }
                    break;
            }
        }
    }
}