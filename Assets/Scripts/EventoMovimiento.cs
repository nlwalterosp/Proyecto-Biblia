using UnityEngine;

public class EventoMovimiento : MonoBehaviour
{
    [SerializeField] private Animator animatorDestino;
    [SerializeField] private string nombreTrigger = "Moverse";

    private bool yaSeEjecuto = false;

    public void EjecutarMovimiento()
    {
        if (animatorDestino != null && !yaSeEjecuto)
        {
            yaSeEjecuto = true;
            animatorDestino.SetTrigger(nombreTrigger);
        }
    }
}