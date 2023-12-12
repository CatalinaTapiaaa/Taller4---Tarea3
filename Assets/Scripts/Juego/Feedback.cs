using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour
{   
    void Update()
    {
        transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
        Destroy(gameObject, 1);
    }
}
