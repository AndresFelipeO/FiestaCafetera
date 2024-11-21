using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{

    private Slider _slider;
    private Animator _animator;

    void Start()
    {
        this._slider = GetComponent<Slider>();
        this._animator = GetComponent<Animator>();
    }

    public void CambiarVidaMaxima(float vidaMaxima){
        this._slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida){
        this._slider.value = cantidadVida;
        this._animator.SetTrigger("Golpe");

    }

    public void InicializarBarraDeVida(float cantidadVida){
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }

}
