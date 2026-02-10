using UnityEngine;

public class Destruir_Meteoro : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // destruye el objeto que contenga este script
        if (other.CompareTag("Suelo"))
        {
            Destroy(gameObject);

        }
    }
}
