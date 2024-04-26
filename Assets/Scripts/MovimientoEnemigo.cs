using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform[] waypointArray;
    public List<Transform> waypoints = new List<Transform>();
    public Dictionary<string, Transform> waypointsDiccionario = new Dictionary<string, Transform>();

    int waypointActual = 0;
    float distanciaMinima = 0.5f, velocidad = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nuevaPosicion =  new Vector3 (waypointArray[waypointActual].position.x, transform.position.y);


        Vector3 movimiento = (nuevaPosicion - transform.position).normalized * velocidad * Time.deltaTime;

        if(Mathf.Sign(movimiento.x)!= Mathf.Sign(transform.localScale.x))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        transform.position += movimiento;




        if(Vector3.Distance(nuevaPosicion, transform.position) < distanciaMinima)
        {
            waypointActual++;
            if(waypointActual >= waypointArray.Length)
            {
                waypointActual = 0;
            }
        }
    }
}
