using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntuacionManager : MonoBehaviour
{
    public TextMeshProUGUI textArriba;
    public TextMeshProUGUI textAbajo;
    [Space]
    public int nivel;
    public bool masDificultad;

    public void Start()
    {
        DataManager.data.puntuacionArriba = 0;
        DataManager.data.puntuacionAbajo = 0;
        DataManager.Save();
    }

    void Update()
    {
        textArriba.text = DataManager.data.puntuacionArriba.ToString();
        textAbajo.text = DataManager.data.puntuacionAbajo.ToString();
    }

    public void SumarPuntajeAbajo()
    {
        nivel++;
        masDificultad = true;
        DataManager.data.puntuacionAbajo += 1;
        DataManager.Save();
    }
    public void SumarPuntajeArriba()
    {
        nivel++;
        masDificultad = true;
        DataManager.data.puntuacionArriba += 1;
        DataManager.Save();
    }
}
