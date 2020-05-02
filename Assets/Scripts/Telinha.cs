using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Telinha : MonoBehaviour
{
    [SerializeField] private Sprite[] imagens;
    [SerializeField] private Image filtro;
    [SerializeField] private GameObject continuar;
    private int index;

    private void Start()
    {
        Player.telinha = true;   
    }

    void Update()
    {
        print(Player.move);
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
            StartCoroutine("Espera");
        }
    }

    public IEnumerator Espera()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.2f);
        Player.telinha = false;
        Time.timeScale = 1;
        filtro.gameObject.SetActive(true);
        ObstaculosBehaviour.boost = true;
        Destroy(this.gameObject);
    }
}
