using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicClass : MonoBehaviour
{
    private static GameObject ambientInstance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (ambientInstance == null)
        {
            ambientInstance = transform.gameObject;
            DontDestroyOnLoad(ambientInstance);
            audioSource = GetComponent<AudioSource>();
            PlayMusic();
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    private void Update()
    {
        if (PauseMenu.isGamePaused)
        {
            audioSource.pitch = 0.7f;
        }
        else
        {
            audioSource.pitch = 1f;
        }
        
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(ambientInstance);
        }
    }
}
