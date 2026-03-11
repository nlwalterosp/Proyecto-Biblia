using UnityEngine;

public class PersonajeLlora : MonoBehaviour
{
    public ControlClima clima;

    public void EmpezarLlorar()
    {
        clima.ActivarTormenta();
    }


}