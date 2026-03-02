using UnityEngine;

public class PlanetaController : MonoBehaviour
{
    public Animator animatorPlaneta;
    public NinoEventos nino;

    public void SubirPlaneta()
    {
        animatorPlaneta.SetTrigger("Planeta_Subir");
    }

    public void BajarPlaneta()
    {
        animatorPlaneta.SetTrigger("Planeta_Bajar");
    }

    public void AvisarBajadaCompleta()
    {
        if (nino != null)
        {
            nino.Saludar();
        }
    }
}