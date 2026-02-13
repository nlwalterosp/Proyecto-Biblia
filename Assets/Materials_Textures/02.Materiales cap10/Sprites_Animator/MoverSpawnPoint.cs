using UnityEngine;

public class MoverSpawnPoint : MonoBehaviour
{
    public float rangoX = 1f;
    public float velocidad = 0f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float offsetX = Mathf.Sin(Time.time * velocidad) * rangoX;

        transform.position = new Vector3(
            posicionInicial.x + offsetX,
            posicionInicial.y,
            posicionInicial.z
        );
    }
}
