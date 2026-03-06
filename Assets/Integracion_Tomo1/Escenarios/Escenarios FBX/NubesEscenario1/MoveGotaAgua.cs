using UnityEngine;

public class MoveGotaAgua : MonoBehaviour
{
    public float velocidad = 1.5f;
    public GameObject splash;

    void Update()
    {
        transform.position += Vector3.down * velocidad * Time.deltaTime;
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

            Destroy(efecto, 0.4f);

            Destroy(gameObject);
        }
    }
}