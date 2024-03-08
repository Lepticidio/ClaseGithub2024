using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    public float velocidad = 2;



    // Start is called before the first frame update
    void Start()
    {


        
    }




    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(velocidad, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(velocidad, 0, 0) * Time.deltaTime;
        }

    }
}
