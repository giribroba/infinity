using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorObstaculos : MonoBehaviour
{
    [SerializeField] private GameObject virus, camisinha, remedio;
    [SerializeField] private Vector2 posicao1, posicao2, posicao3;
    [SerializeField] private float spawnTime, spawnCamisinhaCooldown;
    private float spawnCooldown, numeroRandom, index;
    private GameObject clone;
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
            posicao = numeroRandom == -1 ? posicao3 : numeroRandom == 0 ? posicao2 : posicao1;
            if(index >= spawnCamisinhaCooldown)
            {
                clone = Instantiate(camisinha, posicao, Quaternion.identity);
                index = 0;
            }
            else
            {
                clone = Instantiate(virus, posicao, Quaternion.identity);
                index++;
            }
            clone.GetComponent<ObstaculosBehaviour>().Pista = numeroRandom;
            spawnCooldown = Time.time + spawnTime;

        }
    }
}
