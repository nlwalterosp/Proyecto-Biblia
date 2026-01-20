using UnityEngine;

public class AjustarPosicionAR : MonoBehaviour
{
    [Header("Offset desde el target a la hoja")]
    // AJUSTA ESTOS VALORES CRÍTICAMENTE:
    public Vector3 offsetDesdeTarget = new Vector3(-0.2f, 0.1f, 0.15f);

    [Header("Escala")]
    public Vector3 escalaGrande = new Vector3(3, 3, 3);

    void Start()
    {
        // Aplicar offset para mover de la esquina al centro de la hoja
        transform.localPosition = offsetDesdeTarget;
        transform.localScale = escalaGrande;

        Debug.Log($"Modelo movido a posición: {transform.localPosition}");
    }
}