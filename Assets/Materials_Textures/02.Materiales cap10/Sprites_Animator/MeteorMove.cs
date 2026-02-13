using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    public float speedFall;
    public Vector3 diretion;

    public GameObject explosion;


    // Update is called once per frame
    void Update()
    {
        speedFall = Random.Range(3, 5);

        transform.Translate(diretion * speedFall * Time.deltaTime);
    }
}

