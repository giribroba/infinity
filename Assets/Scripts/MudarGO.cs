using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarGO : MonoBehaviour
{
    [SerializeField] private GameObject[] objetos;
    void Update()
    {
        if (BotoesMenu.linguagem == 0)
        {
            objetos[0].SetActive(true);
            objetos[1].SetActive(false);
        }
        else
        {
            objetos[1].SetActive(true);
            objetos[0].SetActive(false);
        }
    }
}
