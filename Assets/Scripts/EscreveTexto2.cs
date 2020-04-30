
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscreveTexto2 : MonoBehaviour
{
    private float intervalo = 0.05f;
    private string[] textos;
    private string textoCompleto = "", textoAtual = "", textoAnterior = "";

    [SerializeField] private AudioSource somEscrevendo;

    private void Awake()
    {
        if (BotoesMenu.linguagem == 0)
        {
            textos = new string[] { "Depois da festa ..." };
        }
        else
        {
            textos = new string[] { "After party ..." };
        }
    }

    private void Start()
    {
        StartCoroutine("ApareceTexto");
    }

    public IEnumerator ApareceTexto()
    {
        for (int j = 0; j < textos.Length; j++)
        {
            textoCompleto = textos[j];
            somEscrevendo.Play();
            for (int i = 0; i <= textoCompleto.Length; i++)
            {
                textoAtual = textoAnterior + textoCompleto.Substring(0, i);
                this.GetComponent<Text>().text = textoAtual;
                yield return new WaitForSeconds(intervalo);
            }
            textoAnterior = textoAtual + " ";
            somEscrevendo.Stop();
            yield return new WaitForSeconds(0.5f);
        }
    }
}