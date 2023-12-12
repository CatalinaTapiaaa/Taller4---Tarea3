using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstruo : MonoBehaviour
{
    public PuntuacionManager puntuacionManager;
    public bool activarTap;

    [Header("Comer")]
    public LayerMask layerMask;
    public Transform pivotComer;
    public Transform pivotScore;
    public Animator aniBoca;
    public Animator aniComida;
    public float velocidad;

    [Header("Temblor Camara")]
    public Transform camara;
    public float temblorDuracion;

    [Header("Panel")]
    public GameObject canvasFinal;

    RaycastHit2D hit;
    float temblorCantidad = 0.2f;
    bool temblor;

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
            aniBoca.SetBool("Idle", true);
            GameObject[] scores = GameObject.FindGameObjectsWithTag("Score");
            if (scores.Length == 0)
            {
                activarTap = false;
                canvasFinal.SetActive(true);
            }           

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                StartCoroutine(Tembror());
            }
            if (Input.GetMouseButtonDown(0))
            {
                Temblor();
                StartCoroutine(Comer());
                Destroy(hit.collider.gameObject);
            }
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
        hit.collider.transform.localPosition = Vector3.zero;
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
