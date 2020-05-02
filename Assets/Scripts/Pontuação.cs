using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuação : MonoBehaviour
{
    public static float score;
    private float tempoInicial;
    [SerializeField] private Text scoreText;

    void Start()
    {
        score = 0;
        tempoInicial = Time.time;
    }

    public void Update()
    {
        if(Time.timeScale > 0 && !ControladorObstaculos.tutorial)
            score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.Floor(score);
    }
}
