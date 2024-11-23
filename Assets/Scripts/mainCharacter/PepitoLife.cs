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
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        //TODO: lo dañe no se como funciona santi :c
        //barraDeVida.CambiarVidaActual(health);
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
