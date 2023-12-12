using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI[] puntuacionActual;
    public TextMeshProUGUI[] puntuacionMax;

    [Header("Start")]
    public NivelManager nivelManager;
    public Animator aniStart;
    public Transform pivotSpawn;
    [Header("Replay")]
    public Animator aniReplay;
    //[Header("Credits")]


    void Update()
    {
        
    }

    public void BotonStart()
    {
        pivotSpawn.position += new Vector3(0, 0.8293f, 0);
        int aleatorio = Random.Range(0, nivelManager.scores.Count);
        Instantiate(nivelManager.scores[aleatorio], nivelManager.pivotMover.position, Quaternion.identity);
        nivelManager.temporizador = true;
        aniStart.SetBool("Desactivar", true);
    }
    public void BotonReplay()
    {
        StartCoroutine(Replay());
    }

    IEnumerator Replay()
    {
        aniReplay.SetBool("Activar", true);
        yield return new WaitForSeconds(0.30f);
        SceneManager.LoadScene(1);
    }
}
