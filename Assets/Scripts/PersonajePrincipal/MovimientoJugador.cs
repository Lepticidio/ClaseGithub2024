using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 2, fuerzaSalto = 10;

    public AudioSource fuente;
    public Animator animator;
    public Rigidbody2D rigidbody;
    public DetectorSuelo detectorSuelo;
    public Transform[] checkpoints;

    // Start is called before the first frame update
    void Start()
    {

        int indexCheckpoint = PlayerPrefs.GetInt("Checkpoints", 0);

        if(indexCheckpoint > 0)
        {
            transform.position = checkpoints[indexCheckpoint - 1].position;
        }
        
    }




    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Space) && detectorSuelo.enSuelo)
        {
            rigidbody.AddForceY(fuerzaSalto);
            detectorSuelo.enSuelo = false;
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
        
        if(estaCaminando && !fuente.isPlaying)
        {
            //fuente.volume = 1;            
            fuente.Play();
        }
        else if (!estaCaminando && fuente.isPlaying)
        {
            //fuente.volume = 0;
            fuente.Stop();
        }


        animator.SetBool("Walking", estaCaminando);

        transform.position += velocidadHorizontal;
    }
}
