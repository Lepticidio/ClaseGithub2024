using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgenteNavegacion : MonoBehaviour
{
    public Transform destino;
    public NavMeshAgent agente;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(destino.position);
    }
}
