using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    private float startTouchY, finalTouchY;
    private Touch touch;
    [Range(-1, 1)] private int axisY, pistaAtual;

    void Start()
    {

    }
    void Update()
    {
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
}