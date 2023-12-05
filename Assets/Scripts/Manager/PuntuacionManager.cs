using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PuntuacionManager : MonoBehaviour
{
    public TextMeshProUGUI texto;

    public void Start()
    {
        DataManager.data.puntuacion = 0;
        DataManager.Save();
    }

    private void Update()
    {
        texto.text = DataManager.data.puntuacion.ToString();
    }

    public void SumarPuntaje()
    {
        DataManager.data.puntuacion += 1;
        DataManager.Save();
    }
}
