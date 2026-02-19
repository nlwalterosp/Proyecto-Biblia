using UnityEngine;

public class PlanetaController : MonoBehaviour
{
    public Animator animatorPlaneta;

    public void SubirPlaneta()
    {
        animatorPlaneta.SetTrigger("Planeta_Subir");
    }
}

