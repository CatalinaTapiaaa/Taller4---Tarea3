using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelManager : MonoBehaviour
{
    public List<GameObject> scores = new List<GameObject>();
    public PuntuacionManager puntuacionManager;
    public Monstruo monstruo;

    [Header("Barra Temporizador")]
    public Image barra;
    public float velocidadTiempo;
    public bool temporizador;
    float t = 10;

    [Header("Mover")]
    public Transform pivotMover;
    public AnimationCurve curve;
    public float smoothTime;
    Vector3 velocity = Vector3.zero;

    [Header("Derrota")]
    public Animator camara;
    public bool desactivar;

    void Update()
    {
        Vector3 a = transform.position;
        Vector3 b = new Vector3(pivotMover.position.x, pivotMover.position.y, transform.position.z);
        Vector3 pos = Vector3.SmoothDamp(a, b, ref velocity, smoothTime);
        transform.position = pos;

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
        pivotMover.position += new Vector3(0, 0.785f, 0);
        puntuacionManager.SumarPuntajeAbajo();
        int aleatorio = Random.Range(0, scores.Count);

        if (direccion == "Derecha")
        {
            Instantiate(scores[aleatorio], pivotMover.position, Quaternion.identity);
        }
        if (direccion == "Izquierda")
        {
            Instantiate(scores[aleatorio], pivotMover.position, Quaternion.identity);
        }
        if (direccion == "Arriba")
        {
            Instantiate(scores[aleatorio], pivotMover.position, Quaternion.identity);
        }
        if (direccion == "Abajo")
        {
            Instantiate(scores[aleatorio], pivotMover.position, Quaternion.identity);
        }
        if (direccion == "Arriba Derecha")
        {
            Instantiate(scores[aleatorio], pivotMover.position, Quaternion.identity);
        }
        if (direccion == "Arriba Izquierda")
        {
            Instantiate(scores[aleatorio], pivotMover.position, Quaternion.identity);
        }
        if (direccion == "Abajo Derecha")
        {
            Instantiate(scores[aleatorio], pivotMover.position, Quaternion.identity);
        }
        if (direccion == "Abajo Izquierda")
        {
            Instantiate(scores[aleatorio], pivotMover.position, Quaternion.identity);
        }

        t = 10;
        desactivar = false;
    }  
    public void Derrota()
    {
        Debug.Log("Derrota");
        StartCoroutine(ActivarMonstruo());
    }
    IEnumerator ActivarMonstruo()
    {
        camara.SetBool("Monstruo", true);
        desactivar = false;
        temporizador = false;
        yield return new WaitForSeconds(1.20f);
        monstruo.activarTap = true;
        monstruo.Comida();
    }
}
