using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelManager : MonoBehaviour
{
    public List<GameObject> scores = new List<GameObject>();
    public Transform pivotSpawn;
    public Transform pivotDestroy;
    public PuntuacionManager puntuacionManager;

    [Header("Barra Temporizador")]
    public Image barra;
    public float velocidadTiempo;
    public bool temporizador;
    float t = 10;

    [Header("Mover")]
    public AnimationCurve curve;
    public float smoothTime;
    public bool abajo;
    Vector3 velocity = Vector3.zero;

    [Header("Derrota")]
    public GameObject panArriba;
    public GameObject tenedor;
    public bool desactivar;

    void Update()
    {
        if (!abajo)
        {
            Vector3 a = transform.position;
            Vector3 b = new Vector3(pivotSpawn.position.x, pivotSpawn.position.y, transform.position.z);
            Vector3 pos = Vector3.SmoothDamp(a, b, ref velocity, smoothTime);
            transform.position = pos;
        }
        if (abajo)
        {
            Vector3 a = transform.position;
            Vector3 b = new Vector3(pivotDestroy.position.x, pivotDestroy.position.y, transform.position.z);
            Vector3 pos = Vector3.SmoothDamp(a, b, ref velocity, smoothTime);
            transform.position = pos;
        }

        if (temporizador)
        {
            t -= velocidadTiempo * Time.deltaTime;

            if (t <= 0)
            {
                Derrota();
                temporizador = false;
            }
        }     
        barra.fillAmount = t / 10;
    }


    public void Victoria(string direccion)
    {
        Debug.Log("Victoria");
        pivotSpawn.position += new Vector3(0, 1.08f, 0);
        puntuacionManager.SumarPuntaje();
        int aleatorio = Random.Range(0, scores.Count);

        if (direccion == "Derecha")
        {
            Instantiate(scores[aleatorio], pivotSpawn.position, Quaternion.identity);
        }
        if (direccion == "Izquierda")
        {
            Instantiate(scores[aleatorio], pivotSpawn.position, Quaternion.identity);
        }
        if (direccion == "Arriba")
        {
            Instantiate(scores[aleatorio], pivotSpawn.position, Quaternion.identity);
        }
        if (direccion == "Abajo")
        {
            Instantiate(scores[aleatorio], pivotSpawn.position, Quaternion.identity);
        }
        if (direccion == "Arriba Derecha")
        {
            Instantiate(scores[aleatorio], pivotSpawn.position, Quaternion.identity);
        }
        if (direccion == "Arriba Izquierda")
        {
            Instantiate(scores[aleatorio], pivotSpawn.position, Quaternion.identity);
        }
        if (direccion == "Abajo Derecha")
        {
            Instantiate(scores[aleatorio], pivotSpawn.position, Quaternion.identity);
        }
        if (direccion == "Abajo Izquierda")
        {
            Instantiate(scores[aleatorio], pivotSpawn.position, Quaternion.identity);
        }

        t = 10;
        desactivar = false;
    }  
    public void Derrota()
    {
        Debug.Log("Derrota");
        StartCoroutine(Satisfaccion());

        abajo = true;
        desactivar = false;
        temporizador = false;
    }
    IEnumerator Satisfaccion()
    {
        panArriba.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        pivotDestroy.position += new Vector3(0, 3f, 0);
        tenedor.SetActive(true);
    }
}
