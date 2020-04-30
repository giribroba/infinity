using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    void Update()
    {
        if(BotoesDif.som)
            this.GetComponent<AudioSource>().volume = 1;
        else
            this.GetComponent<AudioSource>().volume = 0;
    }
}
