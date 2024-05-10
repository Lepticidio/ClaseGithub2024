using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    public float velocidad, mana, tiempoDesdeUltimoAtaque, cooldown = 1, costeMana = 10, manaMaximo = 100;
    public GameObject prefabProyectil;
    public Transform puntoCreacion, barra;
    // Start is called before the first frame update
    void Start()
    {
        mana = manaMaximo;
        ActualizarBarra();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDesdeUltimoAtaque += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && tiempoDesdeUltimoAtaque  > cooldown && mana >= costeMana)
        {
            Proyectil proyectil =   Instantiate(prefabProyectil).GetComponent<Proyectil>();

            proyectil.transform.position = puntoCreacion.transform.position;

            proyectil.rigidbody.velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - proyectil.transform.position).normalized * velocidad;

            mana -= costeMana;
            ActualizarBarra();
            tiempoDesdeUltimoAtaque = 0;
        }
    }

    public void ActualizarBarra()
    {
        barra.localScale = new Vector2(mana / manaMaximo , 1);
    }
}
