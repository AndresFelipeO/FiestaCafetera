using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepitoLife : MonoBehaviour
{
    public int health = 3;
    public int damageEnemy = 1;
    public BarraDeVida barraDeVida;

    void Start()
    {
        if (barraDeVida == null)
        {
            Debug.LogError("BarraDeVida no asignada en el inspector.");
            return;
        }

        barraDeVida.InicializarBarraDeVida(health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("enemy_bullet")) return;
        TakeDamage(damageEnemy);
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (barraDeVida != null)
        {
            barraDeVida.CambiarVidaActual(health);
        }

        if (health <= 0)
        {
            DiePepito();
        }
    }

    private void DiePepito()
    {
        Destroy(gameObject);
    }
}