using UnityEngine;

public class Spawner_Meteoros : MonoBehaviour
{
    public GameObject meteoroPrefabs;
    public float spawnRangeZ;
    public float spawnRangeZMenor;
    public float spawnRangeX;
    public float spawnRangeXMenor;
    public float spawnPosY;

    public float startDalay;
    public float spawnInterval;


    void Start()
    {
        //Inicializa la posicion en Z del objeto
        spawnPosY = transform.position.y;

        // Este metodo sirve para invocat una funcion y hacer que se repita  sucesivamente
        // Se activara desde un tiempo trascurrido ( despues de dos 2 segundos de inicio) y se repetirar en intervalos tiempo (1.5f segundos)
        InvokeRepeating("SpawnRandomAnimals", startDalay, spawnInterval);
    }

    void SpawnRandomAnimals()
    {
        // Genera el random de la del spawn de los meteoros
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeXMenor, spawnRangeX), spawnPosY, Random.Range(-spawnRangeZMenor, spawnRangeZ));

        // Instacia los meteoros
        Instantiate(meteoroPrefabs, spawnPos, meteoroPrefabs.transform.rotation);
    }
}
