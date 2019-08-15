using UnityEngine;
using UnityEngine.SceneManagement;


public class Da2Bo : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("BoHaus");
    }
}
