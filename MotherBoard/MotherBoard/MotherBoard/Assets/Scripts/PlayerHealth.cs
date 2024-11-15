using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image barraVida; // Referencia a la imagen que actúa como barra de vida
    public float vidaActual;
    public float vidamaxima = 100f; // Vida máxima

    void Start()
    {
        // Inicializar la vida actual al máximo al comenzar el juego
        vidaActual = vidamaxima;
        ActualizarBarraDeVida();
    }

    void Update()
    {
        // Aquí podrías implementar otra lógica que modifique la vida actual
        ActualizarBarraDeVida();
    }

    // Método para reducir la vida del jugador
    public void TakeDamage(float cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidamaxima); // Evitar que la vida baje de 0 o supere el máximo
        ActualizarBarraDeVida();

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // Método para actualizar la barra de vida en la UI
    void ActualizarBarraDeVida()
    {
        barraVida.fillAmount = vidaActual / vidamaxima;
    }

    // Método que se llama cuando la vida llega a 0
    void Morir()
    {
        Debug.Log("El jugador ha muerto");
        // Aquí podrías agregar lógica para reiniciar el nivel o mostrar una pantalla de game over
    }
}
