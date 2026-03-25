using UnityEngine;

public class Destruir_Meteoro : MonoBehaviour
{
    public GameObject animExplosion;

    private void OnTriggerEnter(Collider other)
    {
        // destruye el objeto que contenga este script
        if (other.CompareTag("Suelo"))
        {
            InstanExplosion();
            Destroy(gameObject);
            
        }
    }

    void InstanExplosion()
    {
        GameObject explosion = Instantiate(animExplosion, transform.position, Quaternion.identity, transform.parent);
        Destroy(explosion, 2f);
    }
}
