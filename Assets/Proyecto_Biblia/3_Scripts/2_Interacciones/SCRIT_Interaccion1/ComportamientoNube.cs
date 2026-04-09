using UnityEngine;

public class ComportamientoNube : MonoBehaviour
{
    public MeshRenderer meshNube;
    public InstanciaLluvia lluvia;
    public RayosAleatorios rayos;
    public Color colorLluvia = new Color(0.6f, 0.7f, 0.9f);
    public Color colorEden = Color.white;
    public Color colorDestierro = new Color(0.5f, 0.5f, 0.55f);

    public float frontera = 0f;

    void Update()
    {
        if (transform.position.x < frontera)
        {
            // EDEN
            meshNube.material.color = Color.Lerp(
            meshNube.material.color,
            colorEden,
            Time.deltaTime
            );

            if (lluvia != null)
                lluvia.tiempoInicial = Mathf.Lerp(lluvia.tiempoInicial, 1.5f, Time.deltaTime);

            if (rayos != null)
            {
                rayos.permitirRayos = false;
            }
        }
        else
        {
            // DESTIERRO
            meshNube.material.color = Color.Lerp(
                meshNube.material.color,
                 colorLluvia,
                    Time.deltaTime
            
             );

            if (lluvia != null)
                lluvia.tiempoInicial = Mathf.Lerp(lluvia.tiempoInicial, 0.2f, Time.deltaTime);
            if (rayos != null)
            {
                rayos.permitirRayos = true; 
            }
        }
    }
}
