using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoRecuperador { Vida, Mana}
public class Recuperador : MonoBehaviour
{
    public TipoRecuperador tipo = TipoRecuperador.Vida;
    public int valor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Jugador")
        {
            if(tipo == TipoRecuperador.Vida)
            {
                ControladorVida controlVida = FindAnyObjectByType<ControladorVida>();
                controlVida.vida += valor;
                if (controlVida.vida > controlVida.vidaMaxima)
                {
                    controlVida.vida = controlVida.vidaMaxima;
                }
            }
            else
            {
                AtaqueJugador controlAtaque = FindAnyObjectByType<AtaqueJugador>();

                controlAtaque.mana += valor;
                if(controlAtaque.mana > controlAtaque.manaMaximo)
                {
                    controlAtaque.mana = controlAtaque.manaMaximo;
                }
                controlAtaque.ActualizarBarra(); 

            }
            Destroy(gameObject);
        }
    }
}
