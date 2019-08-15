using UnityEngine;
using UnityEngine.SceneManagement;


public class Bo2Da : MonoBehaviour
{
    public GameObject tintin;
    
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("DaHaus");
    }
}
