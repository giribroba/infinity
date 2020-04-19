using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    private float startTouchY, finalTouchY;
    private Touch touch;
    void Start()
    {

    }
    void Update()
    {
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
                    print(startTouchY - finalTouchY < 0 ? "cima" : "baixo");
                    break;
            }
        }
    }
}
