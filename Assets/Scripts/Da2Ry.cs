using UnityEngine;
using UnityEngine.SceneManagement;


public class Da2Ry : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("RyHaus");
    }
}
