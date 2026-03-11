using UnityEngine;

public class ControlClima : MonoBehaviour
{
    public InstanciaLluvia lluvia;
    public RayosAleatorios rayos;

    public void ActivarTormenta()
    {
        lluvia.ActivarLluviaFuerte();
        Invoke("ActivarRayos", 2f);
    }

    void ActivarRayos()
    {
        rayos.enabled = true;
    }
}