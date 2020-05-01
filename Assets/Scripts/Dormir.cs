using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : MonoBehaviour
{
    public void Dormindo()
    {
        this.GetComponent<Animator>().SetTrigger("Dormindo");
    }
}
