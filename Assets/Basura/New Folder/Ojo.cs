using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojo : MonoBehaviour
{
    [Header("Animacion")]
    public Transform centro;
    public float velocidad;
    public float rango;
    public float maxDistancia;
    Vector2 wayPoint;


    void Start()
    {
        NuevoDestino();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, velocidad * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < rango)
        {
            NuevoDestino();
        }
    }

    void NuevoDestino()
    {
        Vector2 centroPos = (centro != null) ? (Vector2)centro.position : Vector2.zero;

        wayPoint = new Vector2(Random.Range(centroPos.x - maxDistancia, centroPos.x + maxDistancia),
                               Random.Range(centroPos.y - maxDistancia, centroPos.y + maxDistancia));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
