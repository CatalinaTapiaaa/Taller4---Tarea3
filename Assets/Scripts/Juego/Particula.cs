using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    public float autoDestroy;

    void Start()
    {
        Destroy(gameObject, autoDestroy);
    }
}
