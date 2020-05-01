using UnityEngine;
using UnityEngine.UI;

public class Telinha : MonoBehaviour
{
    [SerializeField] private Sprite[] imagens;
    private int index;
    void Update()
    {
        if (index >= imagens.Length)
            this.gameObject.SetActive(false);
        else
            this.gameObject.GetComponent<Image>().sprite = imagens[index];
    }

    public void Avancar()
    {
        index++;
    }

    public void Voltar()
    {
        if (index > 0)
            index--;
    }
}
