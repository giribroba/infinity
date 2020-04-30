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

    void Update()
    {
        AtivarBarra();
        axisY = 0;

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

        switch (pistaAtual)
        {
            case 1:
                this.transform.position = new Vector2(this.transform.position.x, -1.4f);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
                break;
            case 0:
                this.transform.position = new Vector2(this.transform.position.x, -2.3f);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
                break;
            case -1:
                this.transform.position = new Vector2(this.transform.position.x, -3.2f);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
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
        if (collision.gameObject.GetComponentInParent<ObstaculosBehaviour>().Pista == pistaAtual)
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