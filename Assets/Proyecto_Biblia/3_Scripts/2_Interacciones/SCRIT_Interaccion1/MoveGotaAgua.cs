using UnityEngine;

public class MoveGotaAgua : MonoBehaviour
{
    public float velocidad = 1.5f;
    public GameObject splash;

    void Update()
    {
        Vector3 direccion = new Vector3(
        -0.3f + Random.Range(-0.1f, 0.1f), -1f,

        Random.Range(-0.05f, 0.05f));

        float velocidadFinal = velocidad + Random.Range(-0.5f, 0.5f);
        transform.position += direccion * velocidadFinal * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            Vector3 puntoImpacto = col.contacts[0].point;

            GameObject efecto = Instantiate(
                splash,
                puntoImpacto,
                Quaternion.identity
            );

            Destroy(efecto, 0.2f);

            Destroy(gameObject);
        }
    }
}