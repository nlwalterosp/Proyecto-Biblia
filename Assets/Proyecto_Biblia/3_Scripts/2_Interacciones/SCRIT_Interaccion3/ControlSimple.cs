using UnityEngine;

public class ControlSimple : MonoBehaviour
{
    public GameObject planeta; // Arrastra el planeta aquí

    float posInicialPlanetaY;
    public float posFinalY;

    private void Start()
    {
        posInicialPlanetaY = planeta.transform.position.y;
    }

    void SubirPlaneta()
    {

        // Esto hace que el planeta suba cuando se llame
        Mathf.Lerp(posInicialPlanetaY, posFinalY = planeta.transform.position.y, 1.0f);
    }
}
