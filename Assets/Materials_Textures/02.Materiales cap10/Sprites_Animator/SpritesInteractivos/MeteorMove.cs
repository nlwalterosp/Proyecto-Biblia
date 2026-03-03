using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    public float speedFall;
    public Vector3 direction;
    public GameObject explosion;

    void Start()
    {
        speedFall = Random.Range(0.2f, 0.4f); // ajusta aquí
    }

    void Update()
    {
        transform.Translate(direction * speedFall * Time.deltaTime);
    }
}

