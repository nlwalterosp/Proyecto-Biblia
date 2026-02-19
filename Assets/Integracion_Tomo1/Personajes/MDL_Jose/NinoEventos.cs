using UnityEngine;

public class NinoEventos : MonoBehaviour
{
    public PlanetaController planeta;

    public void DispararPlaneta()
    {
        planeta.SubirPlaneta();
    }
}
