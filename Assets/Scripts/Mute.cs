using UnityEngine;

public class Mute : MonoBehaviour
{
    [SerializeField] private bool musica;
    [SerializeField] GameObject[] sources;
    public static GameObject existe;
    public static int iMusica;

    void Update()
    {
        if (!musica)
        {
            if (BotoesDif.som)
                this.GetComponent<AudioSource>().volume = 1;
            else
                this.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            if (BotoesDif.musica)
            {
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    this.transform.GetChild(i).GetComponent<AudioSource>().volume = 1;
                }
            }
            else
            {
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    this.transform.GetChild(i).GetComponent<AudioSource>().volume = 0;
                }
            }
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i].SetActive(i == iMusica);
            }
        }
    }
    private void Awake()
    {
        if (musica)
        {
            if (existe != null)
            {
                GameObject.Destroy(this.gameObject);
            }
            else
            {
                existe = this.gameObject;
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }

    public static void Selecionar(int i)
    {
        iMusica = i;
    }
}
