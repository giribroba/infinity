using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculosBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private float pista;
    public float Pista{ get { return pista; } set { pista = value; } }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0) * Time.deltaTime;
    }
}
