using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BotoesMenu : MonoBehaviour
{
    public static int linguagem;//0 = PT, 1 = ENG
    void Start()
    {
        linguagem = PlayerPrefs.GetInt("lang");
    }

    public void MudarLang()
    {
        PlayerPrefs.SetInt("lang", (linguagem == 1 ? 0 : 1));
        linguagem = PlayerPrefs.GetInt("lang");
    }

    public void CarregarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
