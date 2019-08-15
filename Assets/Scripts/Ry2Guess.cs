using UnityEngine;
using UnityEngine.SceneManagement;


public class Ry2Guess : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("GuessWho");
    }
}
