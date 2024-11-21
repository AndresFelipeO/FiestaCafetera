using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepitoLife : MonoBehaviour
{
    public int health=3;
    public int damageEnemy=1;
    public BarraDeVida barraDeVida;

    void Start()
    {
        barraDeVida.InicializarBarraDeVida(health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("enemy_bullet")) return;
        TakeDamage(this.damageEnemy);
        Destroy(other.gameObject);
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        barraDeVida.CambiarVidaActual(health);
        if(health <= 0)
            DiePepito();
    }

    private void DiePepito()
    {
        Destroy(gameObject);
    }
}
