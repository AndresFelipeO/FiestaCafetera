using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepitoLife : MonoBehaviour
{
    public int health = 3; // Vida inicial del personaje
    public int damageEnemy = 1; // Daño recibido por el enemigo
    public BarraDeVida barraDeVida; // Referencia a la barra de vida
    private Animator animator; // Referencia al Animator
    private bool isDead = false; // Bandera para controlar si el personaje está muerto

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
        animator = GetComponent<Animator>();
        if (animator == null)
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
        if (isDead) return;

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
    isDead = true;

    // Activa el parámetro DeathTrigger en el Animator
    if (animator != null)
    {
        animator.SetTrigger("Death"); // Activa el trigger para la animación de muerte
    }   

    }

    // Este método podría llamarse al final de la animación de muerte desde un evento en el Animator
    public void OnDeathAnimationComplete()
    {
        // Reinicia la escena, desactiva el personaje, o cualquier lógica deseada
        Debug.Log("Animación de muerte completada.");
        gameObject.SetActive(false); // Por ejemplo, desactivar el personaje
    }
}
