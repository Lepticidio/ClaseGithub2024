using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    public GameObject panelPausa;
    public void TogglePausa()
    {
        if(Time.timeScale == 1)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            panelPausa.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePausa();
        }
    }
}
