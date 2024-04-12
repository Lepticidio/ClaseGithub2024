using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoPerjudicial : MonoBehaviour
{
    public bool tocaJugador;
    public int dano;


    private void Update()
    {
        if(tocaJugador)
        {
            ControladorVida controlVida = FindAnyObjectByType<ControladorVida>();
            controlVida.vida -= dano * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Jugador")
        {
            tocaJugador = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Jugador")
        {
            tocaJugador = false;
        }

    }
}
