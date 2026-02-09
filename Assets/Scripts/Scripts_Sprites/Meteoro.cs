using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public float speedFall;
    public Vector3 diretion;


    // Update is called once per frame
    void Update()
    {
        speedFall = Random.Range(3, 5);

        transform.Translate(diretion * speedFall * Time.deltaTime);
    }
}
