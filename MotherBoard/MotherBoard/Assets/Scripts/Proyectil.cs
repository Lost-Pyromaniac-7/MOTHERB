using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 20f;
    public float tiempoVida = 5f;

    void Start()
    {
        // Destruir el proyectil después de un tiempo
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}
