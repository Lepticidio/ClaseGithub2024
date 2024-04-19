using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControladorVida : MonoBehaviour
{
    public float vida = 100, vidaMaxima = 100;
    public Image barraVida;
    public Animator animador;
    public FinDeJuego fin;

    // Update is called once per frame
    void Update()
    {
        barraVida.transform.localScale = new Vector2(vida/vidaMaxima, 1 );
        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
        else if (vida > 67)
        {
            barraVida.color = Color.green;
        }
        else if (vida > 33)
        {
            barraVida.color = Color.yellow;
        }
        else
        {
            barraVida.color = Color.red;

            if(vida <= 0)
            {
                vida = 0;

                animador.SetTrigger("muerte");
            }
        }
    }

}
