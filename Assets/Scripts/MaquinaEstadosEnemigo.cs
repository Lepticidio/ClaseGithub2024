using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Estado { Persecucion, Patrulla, Huida }
public class MaquinaEstadosEnemigo : MonoBehaviour
{
    public int puntoPatrullaActual;
    public float vida = 100, distanciaAtaque, distanciaAbandonar, distanciaLlegado = 0.1f, velocidad;
    public Transform jugador;

    public Estado estadoActual = Estado.Patrulla;

    public List<Transform> puntosPatrulla = new List<Transform>();
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
        switch (estadoActual)
        {
            case Estado.Patrulla:


                if (Vector3.Distance(puntosPatrulla[puntoPatrullaActual].position, transform.position) > distanciaLlegado)
                {
                    transform.position += (puntosPatrulla[puntoPatrullaActual].position - transform.position).normalized 
                        * velocidad * Time.deltaTime;
                }
                else
                {
                    puntoPatrullaActual++;

                    if(puntoPatrullaActual >= puntosPatrulla.Count)
                    {
                        puntoPatrullaActual = 0;
                    }
                }


                if (Vector3.Distance(jugador.transform.position, transform.position) < distanciaAtaque)
                {
                    if (vida < 50)
                    {
                        estadoActual = Estado.Huida;
                    }
                    else
                    {
                        estadoActual = Estado.Persecucion;
                    }
                }
                break;
            case Estado.Persecucion:

                transform.position += (jugador.transform.position - transform.position).normalized * velocidad * Time.deltaTime;
                if (Vector3.Distance(jugador.transform.position, transform.position) > distanciaAbandonar)
                {
                    estadoActual = Estado.Patrulla;
                }
                if(vida < 50)
                {
                    estadoActual = Estado.Huida;
                }
                break;

            case Estado.Huida:
                transform.position -= (jugador.transform.position - transform.position).normalized * velocidad * Time.deltaTime;
                if (Vector3.Distance(jugador.transform.position, transform.position) > distanciaAbandonar)
                {
                    estadoActual = Estado.Patrulla;
                }
                break;
        }

    }
}
