using UnityEngine;

public class Intanciador_Bola_Fuego : MonoBehaviour
{
    // Este ccodigo sirve para intanciar la bola de fuego en el escenario
    [SerializeField] GameObject Bolafuego;
    [SerializeField] Transform Posicioninicial;
    public float velocidad_Bola;


    void Start()
    {
        InvokeRepeating("IntanciaBolaFuego",1f,4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IntanciaBolaFuego()
    {

        Vector3 posicionX = new Vector3(Random.Range(0.1f,0.5f), Posicioninicial.transform.position.y, Posicioninicial.transform.position.z);
        Instantiate(Bolafuego, posicionX, Bolafuego.transform.rotation);
    }
}
