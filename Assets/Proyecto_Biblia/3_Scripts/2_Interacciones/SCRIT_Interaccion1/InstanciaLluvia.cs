using UnityEngine;

public class InstanciaLluvia : MonoBehaviour
{
    public GameObject gota;
    public Transform puntoA;
    public Transform puntoB;

    public float tiempoInicial = 0.6f;
    public float tiempoMinimo = 0.15f;
    public float velocidadAumento = 0.02f;

    float tiempoActual;

    void Start()
    {
        tiempoActual = tiempoInicial;
    }

    void CrearGota()
    {
        float x = Random.Range(puntoA.position.x, puntoB.position.x);

        Vector3 posicion = new Vector3(
            x,
            transform.position.y,
            transform.position.z
        );

        Instantiate(gota, posicion, Quaternion.identity, transform);

        // aumentar la lluvia poco a poco
        if (tiempoActual > tiempoMinimo)
        {
            tiempoActual -= velocidadAumento;
            CancelInvoke();
            InvokeRepeating(nameof(CrearGota), 0f, tiempoActual);
        }
    }
    public void ActivarLluviaFuerte()
    {
        tiempoActual = 0.1f;

        CancelInvoke();
        InvokeRepeating(nameof(CrearGota), 0f, tiempoActual);
    }

    void OnDisable()
    {
        CancelInvoke();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void OnEnable()
    {
        CancelInvoke();
        tiempoActual = tiempoInicial;
        InvokeRepeating(nameof(CrearGota), 0f, tiempoActual);
    }
}