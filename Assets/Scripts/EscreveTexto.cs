
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscreveTexto : MonoBehaviour
{
    private float intervalo = 0.05f;
    private string[] textos;
    private string textoCompleto = "", textoAtual = "", textoAnterior = "";

    [SerializeField] private AudioSource somEscrevendo;

    private void Awake()
    {
        if (BotoesMenu.linguagem == 0)
        {
            textos = new string[] { "Você está na pele de Ariel!", "Você ama dar rolês nas horas vagas (todas) e se divertir bastante,", "um dos seus passatempos preferidos é fofocar sobre os fatos da sua vida e da vida alheia (quem nunca, vei?) com seus amiguinhos." };
        }
        else
        {
            textos = new string[] { "Now you are in Ariel’s shoes!", "You love hanging out with your friends in your free time (literally, all the time),and having lots of fun.", "One of your favorite hobbies is gossiping about your life and also everybody else's (who hasn't, right??) with your besties." };
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
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Conv1(new)");
    }
}