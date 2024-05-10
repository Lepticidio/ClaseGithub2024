using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float tiempoTranscurrido, tiempoDeVida, dano;
    public Rigidbody2D rigidbody;
   

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if(tiempoTranscurrido > tiempoDeVida)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemigo")
        {
            MaquinaEstadosEnemigo enemigo = collision.GetComponent<MaquinaEstadosEnemigo>();
            enemigo.vida -= dano;
            Destroy(gameObject);
        }


    }
}
