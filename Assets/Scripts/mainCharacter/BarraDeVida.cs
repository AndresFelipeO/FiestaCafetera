using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour   

{
    public List<Image> corazones; 

    public void InicializarBarraDeVida(int cantidadCorazones)
    {

        for (int i = 0; i < cantidadCorazones; i++)
        {
            corazones[i].gameObject.SetActive(true);
        }
    }

    public void CambiarVidaActual(int cantidadCorazonesRestantes)
    {

        for (int i = corazones.Count - 1; i >= cantidadCorazonesRestantes; i--)
        {
            corazones[i].gameObject.SetActive(false);
        }
    }
}