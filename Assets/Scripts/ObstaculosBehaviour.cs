using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculosBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed, speedVelMax;
    private float speedreal;
    private float pista;
    public float Pista{ get { return pista; } set { pista = value; } }
    // Start is called before the first frame update
    void Start()
    {
        speedreal = speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9.63f)
            Destroy(gameObject);
        print(speedreal + " OBSTACULOS");
        Player.ProgressaoDificuldade(ref speed, speedVelMax, speedreal);
        rb.velocity = new Vector2(speedreal, 0) * Time.deltaTime;
    }
}
