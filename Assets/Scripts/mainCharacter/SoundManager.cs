using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Referencias a los clips de sonido
    [Header("Audio Clips")]
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip deathClip;

    [SerializeField] private AudioClip runningClip;

    // AudioSource para reproducir los sonidos
    private AudioSource _audioSource;

    private void Awake()
    {
        // Inicializa el AudioSource
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource no encontrado en el GameObject.");
        }
    }

    // Métodos para reproducir sonidos
    public void PlayShootSound()
    {
        PlaySound(shootClip);
    }

    public void PlayJumpSound()
    {
        PlaySound(jumpClip);
    }

    public void PlayHurtSound()
    {
        PlaySound(hurtClip);
    }

    public void PlayDeathSound()
    {
        PlaySound(deathClip);
    }

      public void PlayRunningSound()
    {
        PlaySound(runningClip);
    }


    // Método genérico para reproducir un sonido
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}
