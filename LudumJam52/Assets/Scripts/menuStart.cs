using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuStart : MonoBehaviour
{
    //protected ScoreManager scoremanager;
    private Text final_puntaje;

    void Start()
    {
        /* scoremanager = FindObjectOfType<ScoreManager>();
        if (scoremanager)
        {
            final_puntaje = GameObject.Find("finalscore").GetComponent<Text>();
            scoremanager.reset_puntaje();
        } */
    }

    public void cambiarescena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void abrirpagina(string url)
    {
        SceneManager.LoadScene(url);
    }

}
