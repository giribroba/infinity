using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorObstaculos : MonoBehaviour
{
    [SerializeField] private GameObject virus, camisinha, remedio;
    [SerializeField] private Vector2 posicao1, posicao2, posicao3;
    [SerializeField] private float spawnTime, spawnCamisinhaCooldown, spawnTimeVelMax;
    private float spawnCooldown, numeroRandom, index, min;
    private bool execute = true, execute2 = true;
    public static bool aviso1, tutorial = true, aviso2;
    private GameObject clone;
    private Vector2 posicao;

    private void Awake()
    {
        tutorial = PlayerPrefs.GetFloat("tutorial") == 1 ? false : true;
    }
    void Start()
    {
        tutorial = PlayerPrefs.GetFloat("tutorial") == 1 ? false : true;
        index = 0;
        min = spawnTime;
        aviso1 = false;
        aviso2 = false;
    }

    void Update()
    {
        if (!tutorial)
        {
            Player.move = true;
            Spawn();
            Player.ProgressaoDificuldade(ref spawnTime, spawnTimeVelMax, min);
            print(spawnTime);
        }
        else if(execute)
        {
            ObstaculosBehaviour.boost = true;
            clone = Instantiate(virus, posicao2, Quaternion.identity);
            execute = false;
        }
        if (tutorial)
        {
            if(clone.gameObject.transform.position.x <= -2.751225f && !aviso2)
            {
                aviso1 = true;
            }
            if (aviso2 && execute2)
            {
                clone = Instantiate(camisinha, Player.pista == 1 ? posicao1 : posicao3, Quaternion.identity);
                clone.gameObject.GetComponent<ObstaculosBehaviour>().Pista = Player.pista == -1  ? -1 : 1;
                execute2 = false;
            }
        }
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
