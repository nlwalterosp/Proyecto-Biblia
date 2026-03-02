using UnityEngine;

public class NinoEventos : MonoBehaviour
{
    public PlanetaController planeta;
    public Animator animatorNino;

    public void DispararPlaneta()
    {
        planeta.SubirPlaneta();
    }

    public void Saludar()
    {
        animatorNino.SetTrigger("Saludar");
    }
}