using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversa : MonoBehaviour
{
    [SerializeField] private GameObject[] mAnterior, opcoes;
    [SerializeField] private GameObject botao;
    [SerializeField] private Transform scroller, puxador;
    [SerializeField] float velocidade, distancia, esperinha;
    private List<GameObject> aOpcoes = new List<GameObject>();
    private GameObject resposta, ultimaMensagem;
    private RectTransform rMAnterior, rResposta;
    private bool movendo, digitando;
    private int index;
    private Animator animCanvas;

    private void Awake()
    {
        animCanvas = this.GetComponent<Animator>();
    }

    private void Update()
    {

        if (ultimaMensagem != null && ultimaMensagem.transform.position.y <= -2.2f)
        {
            scroller.Translate(Vector2.left * Time.deltaTime * velocidade / 2);
        }
        else if (!digitando && resposta != null && resposta.transform.localPosition == new Vector3(mAnterior[index].transform.localPosition.x + rMAnterior.rect.height + rResposta.rect.height - distancia, 100))
        {
            movendo = false;
            if (index < mAnterior.Length - 1)
            {
                digitando = true;
                StartCoroutine("Digitando");
            }
            else
            {
                botao.SetActive(true);
                //Time.timeScale = 0;
            }
        }

        if (movendo)
        {
            foreach (var i in aOpcoes)
            {
                i.SetActive(resposta.name == i.name);
            }

            resposta.transform.localPosition = Vector2.MoveTowards(resposta.transform.localPosition, new Vector2(mAnterior[index].transform.localPosition.x + rMAnterior.rect.height + rResposta.rect.height - distancia, 100), velocidade);
        }
    }

    public void Iniciar()
    {
        mAnterior[0].SetActive(true);
    }

    public void Respondido(GameObject tempResposta)
    {
        animCanvas.SetTrigger("Resp");
        aOpcoes.Clear();
        resposta = tempResposta;
        resposta.GetComponent<Button>().enabled = false;
        rResposta = resposta.GetComponent<RectTransform>();
        rMAnterior = mAnterior[index].GetComponent<RectTransform>();
        resposta.transform.parent = scroller.transform;

        for (int i = 0; i < opcoes[index].transform.childCount; i++)
        {
            aOpcoes.Add(opcoes[index].transform.GetChild(i).gameObject);
        }

        movendo = true;
    }

    public void Opcoes()
    {
        digitando = false;
        opcoes[index].SetActive(true);
        animCanvas.SetTrigger("Resp1");
    }

    public void Pergunta()
    {
        if (index < mAnterior.Length - 1)
        {
            index++;
        }

        mAnterior[index].transform.localPosition = new Vector3(resposta.transform.localPosition.x + resposta.GetComponent<RectTransform>().rect.height + mAnterior[index].GetComponent<RectTransform>().rect.height - distancia, -100);
        mAnterior[index].SetActive(true);
        ultimaMensagem = mAnterior[index];
    }

    private IEnumerator Digitando()
    {
        yield return new WaitForSeconds(esperinha);
        animCanvas.SetTrigger("Digitando");
    }
}
