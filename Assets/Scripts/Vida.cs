using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] private ParticleSystem particula;
    [SerializeField] private GameObject barraMovel, barraPreenchedora;
    [SerializeField] private float vida, velocidade;
    private Image iBarraPreenchedora;
    private Renderer rParticula;
    void Start()
    {
        rParticula = particula.GetComponent<Renderer>();
        iBarraPreenchedora = barraPreenchedora.GetComponent<Image>();
    }

    void Update()
    {
        rParticula.material.color = iBarraPreenchedora.color;
        particula.transform.position = barraMovel.transform.position - (Vector3.right * 0.05f);

        iBarraPreenchedora.fillAmount = vida / 100;
        iBarraPreenchedora.color = new Color(1, 0, vida / 100);
        barraMovel.transform.localPosition = (Vector2.right * 178 * vida / 100) - (Vector2.right * 89);
        vida -= velocidade * Time.deltaTime;
    }
}
