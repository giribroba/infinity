using UnityEngine;
using UnityEngine.UI;

public class Telinha : MonoBehaviour
{
    [SerializeField] private Sprite[] imagens;
    [SerializeField] private Image filtro;
    [SerializeField] private GameObject continuar;
    private int index;
    void Update()
    {
        this.gameObject.GetComponent<Image>().sprite = imagens[index];
        if(index == imagens.Length - 1)
            continuar.SetActive(true);
        else
            continuar.SetActive(false);
    }

    public void Avancar()
    {
        if (index < imagens.Length - 1)
            index++;
        else
            Continuar();
    }

    public void Voltar()
    {
        if (index > 0)
            index--;
    }
    public void Continuar()
    {
        if (index == imagens.Length - 1)
        {
            Time.timeScale = 1;
            filtro.gameObject.SetActive(true);
            ObstaculosBehaviour.boost = true;
            Destroy(this.gameObject);
        }
    }
}
