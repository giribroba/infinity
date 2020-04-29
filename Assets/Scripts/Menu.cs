using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
