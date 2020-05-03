using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculosBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speedNormal, speedVelMax, speed;
    private GameObject[] remedios;
    private float speedreal;
    private float pista;
    public static bool boost;

    public float Pista{ get { return pista; } set { pista = value; } }
    // Start is called before the first frame update
    void Start()
    {
        speedreal = speedNormal;
        print(speedNormal);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boost)
        {
            remedios = GameObject.FindGameObjectsWithTag("Remedio");
            speed = speedNormal * 3;
            foreach (var i in remedios)
            {
                if (i.transform.position.x <= -2)
                {
                    boost = false;
                    break;
                }
            }
        }
        else
            speed = speedNormal;
        if (ControladorObstaculos.aviso1 && ControladorObstaculos.tutorial)
            speedNormal = 0;
        else if (ControladorObstaculos.aviso2)
            speedNormal = speedreal;
        if (transform.position.x < -15)
            Destroy(gameObject);
        if (!ControladorObstaculos.tutorial)
        {
            Player.ProgressaoDificuldade(ref speedNormal, speedVelMax, speedreal);
        }
        rb.velocity = new Vector2(speed, 0) * Time.deltaTime;
    }
}
