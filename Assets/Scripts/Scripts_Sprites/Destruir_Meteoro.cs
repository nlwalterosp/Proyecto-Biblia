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
        Instantiate(animExplosion,this.transform.position,Quaternion.identity);
    }
}
