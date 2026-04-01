using UnityEngine;

public class Personaje_Adam_Eva_Llora : MonoBehaviour
{
    public ControlClima clima;

    public void EmpezarLlorar()
    {
        clima.ActivarTormenta();
    }


}