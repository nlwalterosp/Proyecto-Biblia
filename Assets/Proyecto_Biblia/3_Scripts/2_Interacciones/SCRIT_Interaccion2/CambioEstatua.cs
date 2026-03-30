using UnityEngine;
using System.Collections;

public class CambioEstatua : MonoBehaviour
{
    [SerializeField] Renderer meshRenderer;
    [SerializeField] float duracion = 2f;

    Material mat;

    void Start()
    {
        mat = meshRenderer.material;
        mat.SetFloat("_Blend", 0f); // empieza normal
    }

    public void ActivarEstatua()
    {
        StartCoroutine(Transformar());
    }

    IEnumerator Transformar()
    {
        float tiempo = 0;

        while (tiempo < duracion)
        {
            float t = tiempo / duracion;

            float valor = Mathf.SmoothStep(0, 1, t);

            mat.SetFloat("_Blend", valor);

            tiempo += Time.deltaTime;

            yield return null;
        }

        mat.SetFloat("_Blend", 1f);
    }
}