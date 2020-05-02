using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject barraVida, imageSifilisPTBR, imageSifilisEN, bolha, maoTutorial;
    public float velocidade, min;
    [SerializeField] private float velocidadeMax;
    [SerializeField] private Text tutorial;
    private float startTouchY, finalTouchY;
    private Touch touch;
    private bool shield, move;
    public static bool execute = true;
    public static bool doente;
    [Range(-1, 1)] private int axisY, pistaAtual;
    public static float pista;
    private GameObject[] obstaculos;
    [SerializeField]private Image filtro;

    void Start()
    {
        tutorial.text = BotoesMenu.linguagem == 0 ? "Cuidado com a sífilis!! não vai querer pegar uma IST certo?" : "Beware with syphilis!! You don't want to have STI, right?";
        PlayerPrefs.SetInt("botao", 1);
        execute = true;
        min = velocidade;
    }
    void Update()
    {
        print(pista);
        if (ControladorObstaculos.tutorial)
        {
            if (ControladorObstaculos.aviso1)
            {
                tutorial.gameObject.SetActive(true);
                maoTutorial.SetActive(true);
                move = true;
            }
        }
        bolha.SetActive(shield ? true : false);
        ProgressaoDificuldade(ref velocidade, velocidadeMax, min);
        AtivarBarra();
        axisY = 0;
        if (move)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startTouchY = Input.mousePosition.y;
            }
            if (Input.GetMouseButtonUp(0))
            {
                finalTouchY = Input.mousePosition.y;
                if (startTouchY - finalTouchY != 0)
                    axisY = (startTouchY - finalTouchY < 0 ? 1 : -1);
            }
        }
#if UNITY_STANDALONE
        if (Input.GetButtonDown("Down"))
        {
            axisY = -1;
        }
        if (Input.GetButtonDown("Up"))
        {
            axisY = 1;
        }
#endif
        pistaAtual += axisY;
        if (pistaAtual < -1)
            pistaAtual = -1;

        if (pistaAtual > 1)
            pistaAtual = 1;
        pista = pistaAtual;
        switch (pistaAtual)
        {
            case 1:
                this.transform.position = new Vector2(this.transform.position.x, -1.4f);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
                if (ControladorObstaculos.tutorial && ControladorObstaculos.aviso1)
                {
                    ControladorObstaculos.aviso1 = false;
                    ControladorObstaculos.aviso2 = true;
                    maoTutorial.SetActive(false);
                    move = false;
                    tutorial.text = BotoesMenu.linguagem == 0 ? "Não conte com a sorte, proteja-se" : "It's better not to test your luck and just protect yourself";
                }
                break;
            case 0:
                this.transform.position = new Vector2(this.transform.position.x, -2.3f);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
                break;
            case -1:
                this.transform.position = new Vector2(this.transform.position.x, -3.2f);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                if (ControladorObstaculos.tutorial)
                {
                    ControladorObstaculos.aviso1 = false;
                    ControladorObstaculos.aviso2 = true;
                    maoTutorial.SetActive(false);
                    move = false;
                    tutorial.text = BotoesMenu.linguagem == 0 ? "Não conte com a sorte, proteja-se" : "It's better not to test your luck and just protect yourself";
                }
                break;
        }
    }
    public static void ProgressaoDificuldade(ref float velocidade, float multiplicadorPerfeito, float min)
    {
        if (Pontuação.score <= 300)
        {
            velocidade = Pontuação.score  * multiplicadorPerfeito + min;
        }
        else
            velocidade = 300 * multiplicadorPerfeito + min;
    }
    private void AtivarBarra()
    {
        if (doente)
        {
            barraVida.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<ObstaculosBehaviour>().Pista == pistaAtual)
        {
            switch (collision.gameObject.tag)
            {
                case "Virus":
                    if (!shield)
                    {
                        doente = true;
                        obstaculos = GameObject.FindGameObjectsWithTag("Pai");
                        foreach(var x in obstaculos)
                        {
                            Destroy(x);
                        }
                        if(BotoesMenu.linguagem == 0)
                        {
                            imageSifilisPTBR.SetActive(true);
                        }
                        else
                        {
                            imageSifilisEN.SetActive(true);
                        }
                        Time.timeScale = 0;
                    }
                    else
                    {
                        shield = false;
                    }
                    break;
                case "Camisinha":
                    shield = true;
                    if (ControladorObstaculos.tutorial)
                    {
                        move = true;
                        print(move);
                        ControladorObstaculos.tutorial = false;
                        tutorial.gameObject.SetActive(false);
                    }
                    break;
                case "Remedio":
                    barraVida.GetComponent<Vida>().VidaVar += 10;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}