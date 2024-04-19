using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bandera : MonoBehaviour
{
    public Animator animador;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Jugador")
        {
            animador.SetTrigger("victoria");
        }
    }
}
