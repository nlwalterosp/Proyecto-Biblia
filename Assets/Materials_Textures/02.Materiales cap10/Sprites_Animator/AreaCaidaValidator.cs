using UnityEngine;

public class AreaCaidaValidator : MonoBehaviour
{
    public LayerMask layerSueloPermitido;
    public float distanciaRay = 1000f;
    public float alturaExtra = 0f;

    // Esta función dice si un punto es válido para caer
    public bool EsPuntoValido(Vector3 origen, out Vector3 puntoFinal)
    {
        if (Physics.Raycast(origen, Vector3.down, out RaycastHit hit, distanciaRay, layerSueloPermitido, QueryTriggerInteraction.Collide))
        {
            puntoFinal = hit.point + Vector3.up * alturaExtra;
            return true;
        }

        puntoFinal = Vector3.zero;
        return false;
    }
}

