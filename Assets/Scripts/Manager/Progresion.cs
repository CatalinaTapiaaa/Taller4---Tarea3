using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    public GameObject[] scores;
    public PuntuacionManager puntuacion;

    NivelManager nivelManager;
    bool maxVelocidad;

    void Start()
    {
        nivelManager = gameObject.GetComponent<NivelManager>();
    }

    void Update()
    {
        if (puntuacion.masDificultad)
        { 
            //Derecha
            if (puntuacion.nivel == 3)
            {
                nivelManager.scores.Add(scores[0]);
            }
            //Izquierda
            if (puntuacion.nivel == 4)
            {
                nivelManager.scores.Add(scores[1]);
            }
            //Arriba Derecha
            if (puntuacion.nivel == 8)
            {
                nivelManager.scores.Add(scores[2]);
            }
            //Arriba Izquierda
            if (puntuacion.nivel == 9)
            {
                nivelManager.scores.Add(scores[3]);
            }
            //Abajo Derecha
            if (puntuacion.nivel == 10)
            {
                nivelManager.scores.Add(scores[4]);
            }
            //Abajo Izquierda
            if (puntuacion.nivel == 11)
            {
                nivelManager.scores.Add(scores[5]);
            }

            if (!maxVelocidad)
            {
                if (nivelManager.velocidadTiempo >= 20)
                {
                    maxVelocidad = true;
                }

                nivelManager.velocidadTiempo += 0.5f;
            }

            puntuacion.masDificultad = false;
        }
    }
}

