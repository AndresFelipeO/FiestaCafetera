using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {
        // Verifica que la barra de vida esté asignada
        if (barraDeVida == null)
        {
            Debug.LogError("BarraDeVida no asignada en el inspector.");
            return;
        }

        // Inicializa la barra de vida con el valor actual de vida
        barraDeVida.InicializarBarraDeVida(health);

        // Obtén el Animator asociado al personaje
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("No se encontró un componente Animator en el GameObject.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que colisiona no es un proyectil enemigo, salimos del método
        if (!other.CompareTag("enemy_bullet")) return;

        // Aplica daño al personaje
        TakeDamage(damageEnemy);
    }

    private void TakeDamage(int damage)
    {
        // Si el personaje ya está muerto, no se procesa más daño
        if (_isDead) return;

        // Reduce la vida del personaje
        health -= damage;

        // Actualiza la barra de vida
        if (barraDeVida != null)
        {
            barraDeVida.CambiarVidaActual(health);
        }

        // Si la vida llega a cero o menos, activa la animación de muerte
        if (health <= 0)
        {
            DiePepito();
        }
    }

    private void DiePepito()
    {
        _isDead = true;
        // Activa el parámetro DeathTrigger en el Animator
        if (_animator != null)
        {
            _animator.SetTrigger("Death"); // Activa el trigger para la animación de muerte
        }   
        
        Invoke(nameof(TriggerGameOver), 2f);
       
    
    }

    private void TriggerGameOver()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    // Este método podría llamarse al final de la animación de muerte desde un evento en el Animator
    public void OnDeathAnimationComplete()
    {
        // Reinicia la escena, desactiva el personaje, o cualquier lógica deseada
        Debug.Log("Animación de muerte completada.");
        gameObject.SetActive(false); // Por ejemplo, desactivar el personaje
    }
}
