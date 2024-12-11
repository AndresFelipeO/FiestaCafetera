using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PepitoLife : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public int health = 3; // Vida inicial del personaje
    public int damageEnemy = 1; // Daño recibido por el enemigo
    public BarraDeVida barraDeVida; // Referencia a la barra de vida
    private Animator _animator; // Referencia al Animator
    private bool _isDead = false; // Bandera para controlar si el personaje está muerto
    private bool _isInvulnerable = false; // Bandera para el estado de invulnerabilidad
    private Rigidbody2D _rigidbody2D; // Referencia al Rigidbody2D

    public float knockbackForce = 8f; // Fuerza del salto hacia atrás
    public float invulnerabilityDuration = 3f; // Duración de la invulnerabilidad

     private SoundManager _soundManager;


    void Start()
    {
        if (barraDeVida == null)
        {
            Debug.LogError("BarraDeVida no asignada en el inspector.");
            return;
        }

        barraDeVida.InicializarBarraDeVida(health);

        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("No se encontró un componente Animator en el GameObject.");
        }

        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody2D en el GameObject.");
        }

        _soundManager = FindObjectOfType<SoundManager>();
        if (_soundManager == null)
        {
            Debug.LogError("No se encontró el SoundManager en la escena.");
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("enemy_bullet") || _isInvulnerable) return;

        TakeDamage(damageEnemy);
    }

    private void TakeDamage(int damage)
    {
        if (_isDead) return;

        health -= damage;

        if (barraDeVida != null)
        {
            barraDeVida.CambiarVidaActual(health);
        }

        if (_soundManager != null)
        {
            _soundManager.PlayHurtSound();
        }


        _animator.ResetTrigger("Hurt");
        _animator.SetTrigger("Hurt");



        // Hacer un pequeño salto hacia atrás
        Vector2 knockbackDirection = transform.localScale.x > 0
            ? Vector2.left
            : Vector2.right; // Dirección opuesta a la orientación del personaje
        _rigidbody2D.AddForce(new Vector2(knockbackDirection.x * knockbackForce, knockbackForce), ForceMode2D.Impulse);


        // Activar invulnerabilidad
        StartCoroutine(ActivateInvulnerability());

        if (health <= 0)
        {
            DiePepito();
        }
        
    }

    private IEnumerator ActivateInvulnerability()
    {
        _isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        _isInvulnerable = false;
    }

    private void DiePepito()
    {
        _isDead = true;
        if (_animator != null)
        {
            _animator.SetTrigger("Death");
        }

        if (_soundManager != null)
        {
            _soundManager.PlayDeathSound();
        }

        Invoke(nameof(TriggerGameOver), 5f);
    }

    private void TriggerGameOver()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
