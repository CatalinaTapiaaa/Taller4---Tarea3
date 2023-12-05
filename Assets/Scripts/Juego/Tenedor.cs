using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenedor : MonoBehaviour
{
    [Header("Destruir Score")]
    public PuntuacionManager puntuacionManager;
    public Animator ani;
    public Transform pivotDestroy;
    public bool activarTap;
    [Header("Temblor Camara")]
    public Transform camara;
    public float temblorDuracion;
    public float esperarMenu;

    BoxCollider2D box2D;
    float temblorCantidad = 0.2f;
    bool temblor;

    void Start()
    {
        box2D = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (activarTap)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                pivotDestroy.position -= new Vector3(0, 2.2f, 0);
            }
            if (Input.GetMouseButtonDown(0))
            {
                pivotDestroy.position -= new Vector3(0, 2.2f, 0);
                StartCoroutine(Animacion());
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
        yield return new WaitForSeconds(0.25f);
        ani.SetBool("Activar", false);
    }

    void Temblando()
    {
        StartCoroutine(Tembror());
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            Destroy(collision.gameObject);
            puntuacionManager.SumarPuntaje();
        }
    }
}
