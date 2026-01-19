using UnityEngine;

public class LimitarEnHoja : MonoBehaviour
{
    // TAMAÑO DE TU HOJA (cambia estos números)
    public float ancho = 0.21f;   // 21 centímetros
    public float alto = 0.297f;   // 29.7 centímetros

    void Start()
    {
        // Crear la caja invisible
        BoxCollider caja = gameObject.AddComponent<BoxCollider>();

        // Hacerla del tamaño de tu hoja
        caja.size = new Vector3(ancho, 0.1f, alto); // Ancho, Altura, Largo

        // Centrarla
        caja.center = new Vector3(0, 0.05f, 0);

        // Hacerla SÓLIDA (no traspasable)
        caja.isTrigger = false;

        Debug.Log("✅ Caja invisible creada alrededor de la hoja");
    }
}
