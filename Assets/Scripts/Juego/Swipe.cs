using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class Swipe : MonoBehaviour
{
    public SwipeManager swipeManager;
    public string direccion;
    public bool activar;

    void OnEnable()
    {
        swipeManager.OnSwipe.AddListener(OnSwipe);
    }
    void OnSwipe(string swipe)
    {
        activar = true;
        direccion = swipe;
        
    }
    void OnDisable()
    {
        swipeManager.OnSwipe.RemoveListener(OnSwipe);
    }
}
