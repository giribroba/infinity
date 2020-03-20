using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCenario : MonoBehaviour
{
    public static void Instanciar(Vector2 posicao, GameObject cenario)
    {
        Instantiate(cenario, posicao, Quaternion.identity);
    }
}
