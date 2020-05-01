using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    [SerializeField] private GameObject botaoNFixo;
    void Start()
    {
        botaoNFixo.GetComponent<SpriteRenderer>().enabled = (PlayerPrefs.GetInt("botao") == 1);
        botaoNFixo.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = (PlayerPrefs.GetInt("botao") == 1);
        botaoNFixo.transform.GetChild(0).gameObject.SetActive(PlayerPrefs.GetInt("botao") == 1);
    }
}
