using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public NivelManager nivelManager;
    [Header("Text")]
    public TextMeshProUGUI puntuacionActual;
    public TextMeshProUGUI puntuacionMaxStart;
    public TextMeshProUGUI puntuacionMaxFinal;
    [Header("Animacion")]
    public Animator aniTransicion;

    void Start()
    {
        puntuacionMaxStart.text = DataManager.data.puntuacionArriba.ToString("BEST SCORE : 0");
    }
    void Update()
    {
        puntuacionActual.text = DataManager.data.puntuacionArriba.ToString();
        puntuacionMaxFinal.text = DataManager.data.puntuacionArriba.ToString();
    }

    public void BotonCredits()
    {
        StartCoroutine(Credits());
    }
    public void BotonReplay()
    {
        StartCoroutine(Replay());
    }

    IEnumerator Replay()
    {
        aniTransicion.SetBool("Activar", true);
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(1);
    }
    IEnumerator Credits()
    {
        aniTransicion.SetBool("Activar", true);
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(2);
    }
}
