using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temblor : MonoBehaviour
{
    public float temblorDuracion;
    public float esperarMenu;
    public bool derrota;

    float temblorCantidad = 0.2f;
    float t;
    bool temblor;

    void Update()
    {      
        if (derrota)
        {
            Temblando();
        }   
    }

    IEnumerator Tembror()
    {
        if (temblor)
        {
            yield return null;
        }

        temblor = true;
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0;

        while (elapsed < temblorDuracion)
        {
            float x = Random.Range(-1f, 1f) * temblorCantidad;
            float y = Random.Range(-1f, 1f) * temblorCantidad;
            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        derrota = false;
        temblor = false;
    }
    void Temblando()
    {
        StartCoroutine(Tembror());
    }
}
