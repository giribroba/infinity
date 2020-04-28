using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    private float startTouchY, finalTouchY;
    private Touch touch;
    [Range(-1, 1)] private int axisY, pistaAtual;

    void Update()
    {
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
                break;
            case 0:
                this.transform.position = new Vector2(this.transform.position.x, -2.3f);
                break;
            case -1:
                this.transform.position = new Vector2(this.transform.position.x, -3.2f);
                break;
        }
    }
}