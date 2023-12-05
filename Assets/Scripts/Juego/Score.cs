using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject gameObjectManager;
    public NivelManager nivel;
    public Swipe swipe;
    [Space]
    public GameObject frecha;
    public string direccion;
    public bool desactivar;

    void Start()
    {
        gameObjectManager = GameObject.Find("MANAGERS");
        swipe = gameObjectManager.GetComponent<Swipe>();
        nivel = gameObjectManager.GetComponent<NivelManager>();
    }

    void Update()
    {       
        if (!desactivar)
        {
            if (!nivel.desactivar)
            {
                if (swipe.activar)
                {
                    if (direccion == swipe.direccion)
                    {
                        nivel.Victoria(direccion);
                        desactivar = true;
                    }
                    else
                    {
                        nivel.Derrota();
                        desactivar = true;
                    }
                    frecha.SetActive(false);
                    swipe.activar = false;
                }
            }               
        }
    } 
}
