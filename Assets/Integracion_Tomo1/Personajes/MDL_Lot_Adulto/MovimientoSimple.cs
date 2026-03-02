using UnityEngine;

public class MovimientoSimple : MonoBehaviour
{
    public float distancia = 0.1f;

    private Vector3 inicio;
    private Vector3 destino;
    private float tiempo;
    private float duracion;
    private bool mover = false;

    public void EmpezarMover(float duracionClip)
    {
        inicio = transform.position;
        destino = inicio + transform.forward * distancia;

        tiempo = 0f;
        duracion = duracionClip;
        mover = true;
    }

    public void DetenerMovimiento()
    {
        mover = false;
    }

    void Update()
    {
        if (mover)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracion;

            transform.position = Vector3.Lerp(inicio, destino, t);
        }
    }
}