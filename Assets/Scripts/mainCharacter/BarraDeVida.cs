using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    public List<GameObject> corazonesAnimados; // Lista de GameObjects con corazones animados

    public void InicializarBarraDeVida(int cantidadCorazones)
    {
        for (int i = 0; i < corazonesAnimados.Count; i++)
        {
            var animator = corazonesAnimados[i].GetComponent<Animator>();

            if (i < cantidadCorazones)
            {
                corazonesAnimados[i].SetActive(true); // Activa el corazón
                if (animator != null)
                {
                    animator.SetBool("Danio", false); // Configura el estado inicial como "vivo"
                }
            }
            else
            {
                corazonesAnimados[i].SetActive(false); // Desactiva corazones sobrantes
            }
        }
    }

    public void CambiarVidaActual(int cantidadCorazonesRestantes)
    {
        for (int i = 0; i < corazonesAnimados.Count; i++)
        {
            var animator = corazonesAnimados[i].GetComponent<Animator>();

            if (i < cantidadCorazonesRestantes)
            {
                // Corazón está vivo
                if (animator != null)
                {
                    animator.SetBool("Danio", false);
                }
            }
            else
            {
                // Corazón está muerto
                if (animator != null)
                {
                    animator.SetBool("Danio", true);
                }
            }
        }
    }
}
