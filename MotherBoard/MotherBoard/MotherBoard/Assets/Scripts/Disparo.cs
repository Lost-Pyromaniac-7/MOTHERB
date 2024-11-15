using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject proyectilPrefab; // El prefab del proyectil
    public Transform puntoDisparo;     // El lugar desde donde disparar

    public float fuerzaDisparo = 20f;

    void Update()
    {
        // Si presionamos el botón izquierdo del ratón
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Instanciar el proyectil en la posición y rotación del punto de disparo
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        
        // Obtener el Rigidbody del proyectil para aplicar fuerza
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        rb.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
    }
}
