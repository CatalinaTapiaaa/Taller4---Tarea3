using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuntuacionManager : MonoBehaviour
{
    public int nivel;
    public bool masDificultad;

    public void Start()
    {
        DataManager.data.puntuacion = 0;
        DataManager.Save();
    }

    public void SumarPuntaje()
    {
        nivel++;
        masDificultad = true;
        DataManager.data.puntuacion += 1;
        DataManager.Save();
    }
}
