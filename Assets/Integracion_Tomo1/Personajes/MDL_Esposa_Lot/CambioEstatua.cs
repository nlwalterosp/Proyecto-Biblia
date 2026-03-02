using UnityEngine;

public class CambioEstatua : MonoBehaviour
{
    [SerializeField] private Renderer meshRenderer;

    [SerializeField] private Material materialNormal;
    [SerializeField] private Material materialEstatua;

    public void ActivarEstatua()
    {
        meshRenderer.material = materialEstatua;
    }

    public void VolverNormal()
    {
        meshRenderer.material = materialNormal;
    }
}
