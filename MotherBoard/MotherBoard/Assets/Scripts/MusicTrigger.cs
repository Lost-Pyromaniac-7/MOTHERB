using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public AudioSource musicSource;  // El AudioSource con la música
    public string playerTag = "Player";  // Tag del jugador

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag(playerTag))
        {
            // Reproduce la música
            if (!musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sale es el jugador
        if (other.CompareTag(playerTag))
        {
            // Detiene la música
            if (musicSource.isPlaying)
            {
                musicSource.Stop();
            }
        }
    }
}
