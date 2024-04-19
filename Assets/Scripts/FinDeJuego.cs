using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinDeJuego : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
    }

    public void Reiniciar()
    {

        SceneManager.LoadScene("SampleScene");
    }


    public IEnumerator ReiniciarCorrutina()
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }
}
