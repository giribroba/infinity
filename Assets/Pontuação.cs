using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuação : MonoBehaviour
{
    float score;
    float tempoInicial;
    [SerializeField] private Text scoreText;

    void Start()
    {
        score = 0;
        tempoInicial = Time.time;
    }

    public void Update()
    {
        score = (int)(Time.time - tempoInicial);
        scoreText.text = "Score: " + score;
    }
}
