using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueWithBo : MonoBehaviour
{

    public Text preTintin;
    public Text BoText;
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

        dialogueList.Add("Hi, Mr. Bo! Mind if I ask you a couple of questions?");
        dialogueList.Add("Bo: What do you want to know?");
        treeDic.Add(0, dialogueList);
        dialogueList.Add("When did you left the Diamondhaus?");
        dialogueList.Add("Bo: Around 10 pm.");
        treeDic.Add(1, dialogueList.GetRange(2, 2));
        dialogueList.Add("Did Da steal The Blue?");
        dialogueList.Add("Bo: Yes.");
        treeDic.Add(2, dialogueList.GetRange(4, 2));
        dialogueList.Add("How were you informed of The Blue being stolen?");
        dialogueList.Add("Bo: I heard about it on the Morning News.");
        treeDic.Add(11, dialogueList.GetRange(6, 2));
        treeDic.Add(122, dialogueList.GetRange(6, 2));
        dialogueList.Add("Where did you go afterwards?");
        dialogueList.Add("Bo: I went to a bar.");
        treeDic.Add(12, dialogueList.GetRange(8, 2));
        dialogueList.Add("Did you talk about it with anyone else?");
        dialogueList.Add("Bo: Yes, with Da.");
        treeDic.Add(111, dialogueList.GetRange(10, 2));
        dialogueList.Add("Do you have any special skill or interest in jewelry?");
        dialogueList.Add("Bo: No.");
        treeDic.Add(112, dialogueList.GetRange(12, 2));
        dialogueList.Add("Did you meet anyone there who could confirm this?");
        dialogueList.Add("Bo: Nah, just drank a beer and got back home.");
        treeDic.Add(121, dialogueList.GetRange(14, 2));
        dialogueList.Add("Thank you very much! Have a good day, Sir!");
        dialogueList.Add("I gotta go! I found out who stole The Blue!");
        treeDic.Add(20, dialogueList.GetRange(16, 2));
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            preTintin.text = ("Wanna talk with Bo?");
            BoText.text = "";
            Option1Text.text = "Yes";
            Option2Text.text = "No";
            _treeLevel = 0;
            dialougePanel.gameObject.SetActive(true);
        }
    }

    public void DialogueManager()
    {
        preTintin.text = string.Concat("Tintin: ", treeDic[_treeLevel][0]);
        BoText.text = treeDic[_treeLevel][1];
        _treeLevel = _treeLevel * 10 + 1;
        Option1Text.text = treeDic[_treeLevel][0];
        Option2Text.text = treeDic[_treeLevel+1][0];
    }

    public void DialogueManagerEnd()
    {
        preTintin.text = string.Concat("Tintin: ", treeDic[_treeLevel][0]);
        BoText.text = treeDic[_treeLevel][1];
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
            print("you're in");
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