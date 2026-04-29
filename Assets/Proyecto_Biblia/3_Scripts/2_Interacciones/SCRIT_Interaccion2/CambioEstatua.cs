using UnityEngine;
using System.Collections;

public class CambioEstatua : MonoBehaviour
{
    [SerializeField] Renderer meshRenderer;
    [SerializeField] float duracion = 0.5f;

    [Header("Materiales")]
    [SerializeField] Material materialNormal;
    [SerializeField] Material materialEstatua;

    Material matInstancia;

    void Start()
    {
        // crear instancia del material (MUY IMPORTANTE)
        matInstancia = new Material(materialNormal);
        meshRenderer.material = matInstancia;
    }

    public void ActivarEstatua()
    {
        StopAllCoroutines();
        StartCoroutine(Transicion());
    }

    IEnumerator Transicion()
    {
        float t = 0f;

        while (t < duracion)
        {
            float progreso = t / duracion;

            // 🔥 interpolar color
            Color colorA = materialNormal.color;
            Color colorB = materialEstatua.color;

            Color mezcla = Color.Lerp(colorA, colorB, progreso);

            matInstancia.color = mezcla;

            t += Time.deltaTime;
            yield return null;
        }

        // asegurar material final
        meshRenderer.material = materialEstatua;
    }

    public void Resetear()
    {
        StopAllCoroutines();

        if (meshRenderer == null) return;
        if (materialNormal == null) return;

        if (matInstancia == null)
            matInstancia = new Material(materialNormal);

        matInstancia.color = materialNormal.color;
        meshRenderer.material = matInstancia;
    }
}