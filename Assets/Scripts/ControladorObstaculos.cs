using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorObstaculos : MonoBehaviour
{
    [SerializeField] private GameObject virus, camisinha, remedio;
    [SerializeField] private Vector2 posicao1, posicao2, posicao3;
    [SerializeField] private float spawnTime, spawnCamisinhaCooldown, spawnTimeVelMax;
    private float spawnCooldown, numeroRandom, index, min;
    private GameObject clone;
    private Vector2 posicao;
    void Start()
    {
        index = 0;
        min = spawnTime;
    }

    void Update()
    {
        print(spawnTime + " SPAWN");
        Spawn();
        Player.ProgressaoDificuldade(ref spawnTime, spawnTimeVelMax, min);
    }

    private void Spawn()
    {
        if(spawnCooldown < Time.time)
        {
            numeroRandom = Random.Range(-1, 2);
            posicao = numeroRandom == -1 ? posicao3 : numeroRandom == 0 ? posicao2 : posicao1;
            if (Player.doente)
            {
                clone = Instantiate(remedio, posicao, Quaternion.identity);
            }
            else
            {
                if(index >= spawnCamisinhaCooldown)
                {
                    clone = Instantiate(camisinha, posicao, Quaternion.identity);
                    index = 0;
                    spawnCamisinhaCooldown = Random.Range(3, 6);
                }
                else
                {
                    clone = Instantiate(virus, posicao, Quaternion.identity);
                    index++;
                }
            }
            
            clone.GetComponent<ObstaculosBehaviour>().Pista = numeroRandom;
            switch (numeroRandom)
            {
                case -1:
                    clone.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    break;
                case 0:
                    clone.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    break;
                case 1:
                    clone.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
                    break;
            }
            spawnCooldown = Time.time + spawnTime;

        }
    }
}
