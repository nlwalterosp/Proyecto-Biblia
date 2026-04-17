using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    public float speedFall;
    public Vector3 direction;
    public GameObject explosion;

    void Start()
    {
        speedFall = Random.Range(0.2f, 0.3f);

        if (direction == Vector3.zero)
            direction = Vector3.down;
    }

    void Update()
    {
        transform.position += direction * speedFall * Time.deltaTime;
    }
}