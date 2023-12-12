using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStart : MonoBehaviour
{
    public NivelManager nivelManager;
    public PuntuacionManager puntuacionManager;
    public Swipe swipe;
    public GameObject frecha;
    [Header("Animaciones")]
    public Animator camara;
    public Animator panelTiulo;
    public Animator scoreStart;

    string direccion = "Arriba";
    bool desactivar;
    int aleatorio;

    void Start()
    {
        aleatorio = Random.Range(0, nivelManager.scores.Count);
    }
    void Update()
    {
        if (!desactivar)
        {
            if (swipe.activar)
            {
                if (direccion == swipe.direccion)
                {
                    panelTiulo.SetBool("Desactivar", true);
                    camara.SetBool("Estatico", true);

                    nivelManager.FeedBack();
                    nivelManager.pivotMover.position += new Vector3(0, 0.785f, 0);
                    Instantiate(nivelManager.scores[aleatorio], nivelManager.pivotMover.position, Quaternion.identity);

                    puntuacionManager.SumarPuntajeAbajo();
                    frecha.SetActive(false);

                    nivelManager.temporizador = true;
                    desactivar = true;
                }
                else
                {
                    StartCoroutine(Error());
                }

                swipe.activar = false;
            }
        }
    }

    IEnumerator Error()
    {
        scoreStart.SetBool("Error", true);
        yield return new WaitForSeconds(0.10f);
        scoreStart.SetBool("Error", false);
    }
}
