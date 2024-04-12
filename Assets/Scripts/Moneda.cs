using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{

    public int valor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Jugador")
        {
            ControladorPuntos controlPuntos = FindAnyObjectByType<ControladorPuntos>();
            controlPuntos.puntos += valor;
            controlPuntos.textoPuntos.text = "Puntos: " + controlPuntos.puntos;
            Destroy(gameObject);
        }
    }
}
