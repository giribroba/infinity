using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{
    [SerializeField] private GameObject[] variantes;
    [SerializeField] private float velocidade;
    private float largura;
    private GameObject player;
    private bool chamou = false;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        largura = this.GetComponent<SpriteRenderer>().size.x;
    }
    private void FixedUpdate()
    {
        this.transform.Translate(Vector2.left * player.GetComponent<Player>().velocidade * velocidade);

        if (this.transform.position.x <= 0 && !chamou)
        {
            ControladorCenario.Instanciar(Vector2.right * (this.transform.position.x + largura), variantes[Random.Range(0, variantes.Length)]);
            chamou = true;
        }
        if (this.transform.position.x <= -largura)
        {
            Destroy(this.gameObject);
        }
    }
}
