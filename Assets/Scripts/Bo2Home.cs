using UnityEngine;
using UnityEngine.SceneManagement;


public class Bo2Home : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Start");
    }
}
