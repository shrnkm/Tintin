using UnityEngine;
using UnityEngine.SceneManagement;


public class Ry2Da : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("DaHaus");
    }
}
