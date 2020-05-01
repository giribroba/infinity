using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarMusica : MonoBehaviour
{
    public void Selecionar(int i)
    {
        Mute.iMusica = i;
    }
}
