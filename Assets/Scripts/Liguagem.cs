using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liguagem : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    void Update()
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[BotoesMenu.linguagem];
    }
}
