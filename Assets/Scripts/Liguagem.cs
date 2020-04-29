using UnityEngine;
using UnityEngine.UI;

public class Liguagem : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image[] images;
    [SerializeField] private bool difImages;
    void Update()
    {
        if (this.GetComponent<SpriteRenderer>() != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[BotoesMenu.linguagem];
        }
        if (!difImages)
        {
            this.GetComponent<Image>().sprite = sprites[BotoesMenu.linguagem];
        }
    }

    private void Start()
    {
        if (difImages)
        {
            if (BotoesMenu.linguagem == 0)
            {
                images[0].enabled = true;
                images[1].enabled = false;
            }
            else
            {
                images[0].enabled = false;
                images[1].enabled = true;
            }
        }
    }
}
