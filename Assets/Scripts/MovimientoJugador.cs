using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 2, fuerzaSalto = 10;

    public Animator animator;
    public Rigidbody2D rigidbody;
    public DetectorSuelo detectorSuelo;

    // Start is called before the first frame update
    void Start()
    {


        
    }




    // Update is called once per frame
    void Update()
    {


        if(Input.GetKey(KeyCode.Space) && detectorSuelo.enSuelo)
        {
            rigidbody.AddForceY(fuerzaSalto);
        }


        Vector3 velocidadHorizontal = Vector3.zero;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            velocidadHorizontal = new Vector3(velocidad, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocidadHorizontal = new Vector3(-velocidad, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }


        bool estaCaminando = velocidadHorizontal != Vector3.zero;
        


        animator.SetBool("Walking", estaCaminando);

        transform.position += velocidadHorizontal;
    }
}
