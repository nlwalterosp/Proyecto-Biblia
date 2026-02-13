using UnityEngine;
using System.Collections;

public class Bola_Fuego : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;
    [SerializeField] float movimientoHorizontal = 2f;  // Velocidad hacia la derecha

    private void Update()
    {
        // Vector3.right = eje rojo (X positivo)
        transform.Translate(Vector3.right * movimientoHorizontal * Time.deltaTime);

        // Vector3.down = eje azul negativo (Y negativo)
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);

        // O UNA SOLA LÍNEA:
        // transform.Translate(new Vector3(movimientoHorizontal, -velocidad, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suelo"))  // Cambiado a "Suelo"
        {
            Destroy(gameObject);
        }
    }
}
