using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monstruo : MonoBehaviour
{
    public PuntuacionManager puntuacionManager;
    public bool activarTap;

    [Header("Comer")]
    public LayerMask layerMask;
    public GameObject particula;
    public Transform pivotComer;
    public Transform pivotScore;
    public Animator aniBoca;
    public Animator aniComida;
    public float velocidad;

    [Header("Barra Temporizador")]
    public Image barra;
    public float velocidadTiempo;

    [Header("Temblor Camara")]
    public Transform camara;
    public float temblorDuracion;

    [Header("Panel")]
    public GameObject canvasFinal;

    RaycastHit2D hit;
    float temblorCantidad = 0.2f;
    bool temblor, temporizador;
    float t = 10;

    void Update()
    {
        hit = Physics2D.Raycast(pivotComer.position, -pivotComer.up, 100, layerMask);
        if (hit.collider != null)
        {
            Debug.DrawRay(pivotComer.position, Vector2.down * hit.distance, Color.blue);
        }
        else
        {

        }

        if (activarTap)
        {
            temporizador = true;
            aniBoca.SetBool("Idle", true);
            GameObject[] scores = GameObject.FindGameObjectsWithTag("Score");
            if (scores.Length == 0)
            {
                activarTap = false;
                canvasFinal.SetActive(true);
            }           

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Temblor();
                StartCoroutine(Comer());
                Destroy(hit.collider.gameObject);
                puntuacionManager.SumarPuntajeArriba();
                Instantiate(particula, pivotScore.position, Quaternion.identity);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Temblor();
                StartCoroutine(Comer());
                Destroy(hit.collider.gameObject);
                puntuacionManager.SumarPuntajeArriba();
                Instantiate(particula, pivotScore.position, Quaternion.identity);
            }
        }

        if (temporizador)
        {
            t -= velocidadTiempo * Time.deltaTime;

            if (t <= 0)
            {
                temporizador = false;
                activarTap = false;
                canvasFinal.SetActive(true);
            }
        }

        barra.fillAmount = t / 10;
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

    IEnumerator Comer()
    {
        aniBoca.SetBool("Comer", true);
        yield return new WaitForSeconds(0.25f);
        aniBoca.SetBool("Comer", false);
        Comida();
    }
    IEnumerator AparecerComida()
    {
        hit.collider.transform.position = pivotScore.position;
        hit.collider.transform.parent = pivotScore;
        if (activarTap)
        {
            hit.collider.transform.localPosition = Vector3.zero;
        }
        aniComida.SetBool("Activar", true);
        yield return new WaitForSeconds(0.25f);
        aniComida.SetBool("Activar", false);
    }

    public void Comida()
    {
        StartCoroutine(AparecerComida());
    }

    void Temblor()
    {
        StartCoroutine(Tembror());
    }    
}
