using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject barraVida;
    public float velocidade;
    private float startTouchY, finalTouchY;
    private Touch touch;
    private bool shield;
    public static bool doente;
    [Range(-1, 1)] private int axisY, pistaAtual;

    void Start()
    {

    }
    void Update()
    {
        AtivarBarra();
        axisY = 0;
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchY = touch.position.y;
                    break;
                case TouchPhase.Moved:
                    finalTouchY = touch.position.y;
                    break;
                case TouchPhase.Ended:
                    axisY = (startTouchY - finalTouchY < 0 ? 1 : -1);
                    break;
            }
        }
#elif UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.S))
        {
            axisY = -1;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            axisY = 1;
        }
#endif
        pistaAtual += axisY;
        if (pistaAtual < -1)
            pistaAtual = -1;
        if (pistaAtual > 1)
            pistaAtual = 1;

        switch (pistaAtual)
        {
            case 1:
                this.transform.position = new Vector2(this.transform.position.x, -1.4f);
                break;
            case 0:
                this.transform.position = new Vector2(this.transform.position.x, -2.3f);
                break;
            case -1:
                this.transform.position = new Vector2(this.transform.position.x, -3.2f);
                break;
        }
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
        if (collision.gameObject.GetComponent<ObstaculosBehaviour>().Pista == pistaAtual)
        {
            switch (collision.gameObject.tag)
            {
                case "Virus":
                    if (!shield)
                    {
                        doente = true;
                    }
                    else
                    {
                        shield = false;
                    }
                    break;
                case "Camisinha":
                    shield = true;
                    break;
                case "Remedio":
                    barraVida.GetComponent<Vida>().VidaVar += 10;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}