using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectScript : MonoBehaviour
{

    public RectTransform inspectPanel;
    public static string ObjectName; 
        
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ObjectName = this.name;
            inspectPanel.GetChild(0).GetComponent<Text>().text = string.Concat("Wanna inspect the ", this.name.ToLower(), "?");
            inspectPanel.gameObject.SetActive(true);
        }
        
    }
    
}
