using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotoesDif : MonoBehaviour
{
    public static bool som, musica;
    [SerializeField] private Image iSom, iMusica;
    [SerializeField] private Sprite[] sSom, sMusica;
    void Start()
    {
        iSom.sprite = sSom[PlayerPrefs.GetInt("som")];
        iMusica.sprite = sMusica[PlayerPrefs.GetInt("musica")];
    }

    private void Update()
    {
        som = (PlayerPrefs.GetInt("som") == 0);
        musica = (PlayerPrefs.GetInt("musica") == 0);
    }

    public void Troca(string tipo)
    {
        PlayerPrefs.SetInt(tipo, (PlayerPrefs.GetInt(tipo) == 0 ? 1 : 0));
        iSom.sprite = sSom[PlayerPrefs.GetInt("som")];
        iMusica.sprite = sMusica[PlayerPrefs.GetInt("musica")];
    }
}
