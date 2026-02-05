using UnityEngine;

public class ControlSimple : MonoBehaviour
{
    public GameObject planeta; // Arrastra el planeta aquí

    void SubirPlaneta()
    {
        // Esto hace que el planeta suba cuando se llame
        planeta.transform.position += new Vector3(0, 3, 0);
    }
}
