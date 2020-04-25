using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] private ParticleSystem particula;
    [SerializeField] private GameObject barraMovel, barraPreenchedora;
    [SerializeField] private float vida, velocidade;
    private RectTransform rt;
    private Image iBarraPreenchedora;
    private Renderer rParticula;
    void Start()
    {
        rParticula = particula.GetComponent<Renderer>();
        iBarraPreenchedora = barraPreenchedora.GetComponent<Image>();
        rt = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        rParticula.material.color = iBarraPreenchedora.color;
        particula.transform.position = barraMovel.transform.position - (Vector3.right * 0.05f);

        iBarraPreenchedora.fillAmount = vida / 100;
        iBarraPreenchedora.color = new Color(1, 0, vida / 100);
        barraMovel.transform.localPosition = Vector2.right * (rt.rect.width * vida / 100 - rt.rect.width/2);
        if(vida > 0)
            vida -= velocidade * Time.deltaTime;
    }
}
