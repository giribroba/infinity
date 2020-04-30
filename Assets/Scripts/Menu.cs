using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
