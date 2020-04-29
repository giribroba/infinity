using UnityEngine;
using UnityEngine.UI;
public class TrocaTexto : MonoBehaviour
{
    [SerializeField] private Text[] textos;
    void Start()
    {
        if (BotoesMenu.linguagem == 0)
        {
            textos[0].enabled = true;
            textos[1].enabled = false;
        }
        else
        {
            textos[0].enabled = false;
            textos[1].enabled = true;
        }
    }
}
