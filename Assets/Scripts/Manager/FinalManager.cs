using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    public PuntuacionManager puntuacionManager;
    public Animator aniComienzo;
    public bool activarTap;
    public bool destruir;


    void Update()
    {
        if (activarTap)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                destruir = true;
                puntuacionManager.SumarPuntaje();
            }
        }
    }

    public void Final()
    {
        StartCoroutine(Comenzar());
    }
    IEnumerator Comenzar()
    {
        aniComienzo.SetBool("Activar", true);
        activarTap = true;
        yield return new WaitForSeconds(1);
        activarTap = false;
    }
}
