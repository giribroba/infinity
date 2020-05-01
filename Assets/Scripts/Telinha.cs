using UnityEngine;
using UnityEngine.UI;

public class Telinha : MonoBehaviour
{
    [SerializeField] private Sprite[] imagens;
    [SerializeField] private Image filtro;
    private int index;
    void Update()
    {
        this.gameObject.GetComponent<Image>().sprite = imagens[index];
    }

    public void Avancar()
    {
        if (index < 5)
            index++;
    }

    public void Voltar()
    {
        if (index > 0)
            index--;
    }
    public void Continuar()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        filtro.gameObject.SetActive(true);
    }
}
