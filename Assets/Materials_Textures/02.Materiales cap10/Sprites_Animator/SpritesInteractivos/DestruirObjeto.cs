using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    public float tiempoDestruccion;

    void Update()
    {
        DestruirEsteObjeto(); 
    }

    void DestruirEsteObjeto()
    {
        Destroy(gameObject,tiempoDestruccion);    
    }
}
