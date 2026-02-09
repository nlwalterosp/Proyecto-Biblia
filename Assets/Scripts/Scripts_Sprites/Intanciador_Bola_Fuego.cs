using UnityEngine;

public class Intanciador_Bola_Fuego : MonoBehaviour
{
    // Este ccodigo sirve para intanciar la bola de fuego en el escenario
    [SerializeField] GameObject Bolafuego;
    [SerializeField] Transform Posicioninicial;


    void Start()
    {
        InvokeRepeating("IntanciaBolaFuego",1f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IntanciaBolaFuego() 
    {
        
        Instantiate(Bolafuego,transform.position= new Vector3(Random.Range(2,2),transform.position.y),Bolafuego.transform.rotation);
    }
}
