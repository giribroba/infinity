using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    [SerializeField] private bool musica;
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
                this.GetComponent<AudioSource>().volume = 1;
            else
                this.GetComponent<AudioSource>().volume = 0;
        }
    }
}
