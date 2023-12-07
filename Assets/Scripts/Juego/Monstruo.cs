using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstruo : MonoBehaviour
{
    public PuntuacionManager puntuacionManager;
    public bool activarTap;

    [Header("Mover")]
    public Animator ani;
    public Transform pivotDestroy;

    [Header("Temblor Camara")]
    public Transform camara;
    public float temblorDuracion;

    BoxCollider2D box2D;
    float temblorCantidad = 0.2f;
    bool temblor;


    void Start()
    {
        StartCoroutine(Activar());
        box2D = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {            
        if (activarTap)
        {
            GameObject[] scores = GameObject.FindGameObjectsWithTag("Score");
            if (scores.Length == 0)
            {
                activarTap = false;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                pivotDestroy.position -= new Vector3(0, numero, 0);
                StartCoroutine(Animacion());
                StartCoroutine(Tembror());
                puntuacionManager.SumarPuntaje();
            }
            if (Input.GetMouseButtonDown(0))
            {
                pivotDestroy.position -= new Vector3(0, numero, 0);
                StartCoroutine(Animacion());
                StartCoroutine(Tembror());
                puntuacionManager.SumarPuntaje();
            }

            box2D.enabled = true;
        }

    }

    IEnumerator Tembror()
    {
        if (temblor)
        {
            yield return null;
        }

        temblor = true;
        Vector3 originalPos = camara.localPosition;
        float elapsed = 0;

        while (elapsed < temblorDuracion)
        {
            float x = Random.Range(-1f, 1f) * temblorCantidad;
            float y = Random.Range(-1f, 1f) * temblorCantidad;
            camara.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        camara.localPosition = originalPos;
        temblor = false;
    }
    IEnumerator Animacion()
    {
        ani.SetBool("Activar", true);
        yield return new WaitForSeconds(0.3f);
        ani.SetBool("Activar", false);
    }
    IEnumerator Activar()
    {
        yield return new WaitForSeconds(0.5f);
        activarTap = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            Destroy(collision.gameObject);
        }
    }
}
