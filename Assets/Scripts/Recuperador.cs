using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recuperador : MonoBehaviour
{

    public int valor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Jugador")
        {
            ControladorVida controlVida = FindAnyObjectByType<ControladorVida>();
            controlVida.vida += valor;
            Destroy(gameObject);
        }
    }
}
