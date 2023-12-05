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
    [Header("Replay")]
    public Animator aniReplay;
    //[Header("Credits")]


    void Update()
    {
        puntuacionMax[0].text = DataManager.data.puntuacionMaxima.ToString();
        puntuacionMax[1].text = DataManager.data.puntuacionMaxima.ToString();

        puntuacionActual[0].text = DataManager.data.puntuacion.ToString();
        puntuacionActual[1].text = DataManager.data.puntuacion.ToString();
    }

    public void BotonStart()
    {
        int aleatorio = Random.Range(0, nivelManager.scores.Count);
        Instantiate(nivelManager.scores[aleatorio], nivelManager.pivotSpawn.position, Quaternion.identity);
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
