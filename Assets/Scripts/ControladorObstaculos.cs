using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorObstaculos : MonoBehaviour
{
    [SerializeField] private GameObject virus, camisinha, remedio;
    [SerializeField] private Vector2 posicao1, posicao2, posicao3;
    [SerializeField] private float spawnTime, spawnCamisinhaCooldown;
    private float spawnCooldown, numeroRandom, index;
    private Vector2 posicao;
    void Start()
    {
        index = 0;
    }

    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if(spawnCooldown < Time.time)
        {
            numeroRandom = Random.Range(-1, 2);
            posicao = numeroRandom == -1 ? posicao1 : numeroRandom == 0 ? posicao2 : posicao3;
            if(index >= spawnCamisinhaCooldown)
            {
                Instantiate(camisinha, posicao, Quaternion.identity);
                index = 0;
            }
            else
            {
                Instantiate(virus, posicao, Quaternion.identity);
                index++;
            }
            spawnCooldown = Time.time + spawnTime;
        }
    }
}
