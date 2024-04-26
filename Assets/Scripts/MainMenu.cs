using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("sampleScene");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void EmpezarPartida()
    {
        PlayerPrefs.SetInt("Checkpoints", 0);
    }
}
