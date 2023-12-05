using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelManager : MonoBehaviour
{
    public GameObject[] scores;
    public Transform pivotSpawn;
    public Transform pivotDestroy;
    public PuntuacionManager puntuacionManager;
    public Tenedor Tenedor;

    [Header("Mover")]
    public AnimationCurve curve;
    public float smoothTime;
    public bool abajo;
    Vector3 velocity = Vector3.zero;

    [Header("Derrota")]
    public GameObject panArriba;
    public GameObject tenedor;
    public bool desactivar;

    void Start()
    {
        Instantiate(scores[0], pivotSpawn.position, Quaternion.identity);
    }
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
    }

    public void Victoria(string direccion)
    {
        Debug.Log("Victoria");
        pivotSpawn.position += new Vector3(0, 2.2f, 0);
        puntuacionManager.SumarPuntaje();
        int aleatorio = Random.Range(0, scores.Length);

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

        desactivar = false;
    }  
    public void Derrota()
    {
        Debug.Log("Derrota");
        StartCoroutine(Satisfaccion());
        abajo = true;
        desactivar = false;
    }
    IEnumerator Satisfaccion()
    {
        panArriba.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        pivotDestroy.position += new Vector3(0, 4.4f, 0);
        tenedor.SetActive(true);
        yield return new WaitForSeconds(1f);
        Tenedor.activarTap = true;
    }
}
