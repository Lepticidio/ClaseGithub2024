using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public AudioSource fuente;
    public int valor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Jugador")
        {
            ControladorPuntos controlPuntos = FindAnyObjectByType<ControladorPuntos>();
            controlPuntos.puntos += valor;
            controlPuntos.textoPuntos.text = "Puntos: " + controlPuntos.puntos;
            fuente.PlayOneShot(fuente.clip);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            Invoke("Autodestroy", 1);
        }
    }

    public void Autodestroy()
    {
        Destroy(gameObject);
    }

}
