using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteoroPrefabs;
    public float spawnRangeZ;
    public float minSpawnRangeX;
    public float maxSpawnRangeX;
    public float spawnPosY;

    public float startDelay;
    public float spawnInterval;
    public BoxCollider areaSpawn;
    public float margen = 0.05f; // Ajusta este valor (en metros AR suele ser pequeño)

    public LayerMask layerPersonajes;   // Layer de los personajes
    public float radioChequeo = 0.05f;  // Qué tan cerca consideramos "encima"
    public int intentosMaximos = 10;    // Para no quedarse en bucle infinito




    void Start()
    {
        //Inicializa la posicion en Z del objeto
        spawnPosY = transform.position.y;

        // Este metodo sirve para invocat una funcion y hacer que se repita  sucesivamente
        // Se activara desde un tiempo trascurrido ( despues de dos 2 segundos de inicio) y se repetirar en intervalos tiempo (1.5f segundos)
      //  InvokeRepeating("SpawnRandomAnimals", startDalay, spawnInterval);
    }

    void SpawnRandomAnimals()
    {
        if (areaSpawn == null) return;

        Bounds b = areaSpawn.bounds;

        int intentos = 0;

        while (intentos < intentosMaximos)
        {
            intentos++;

            Vector3 spawnPos = new Vector3(
                Random.Range(b.min.x + margen, b.max.x - margen),
                b.max.y + 0.02f,
                Random.Range(b.min.z + margen, b.max.z - margen)
            );

            // 🔍 Revisar si hay un personaje cerca
            bool hayPersonaje = Physics.CheckSphere(spawnPos, radioChequeo, layerPersonajes);

            if (!hayPersonaje)
            {
                Instantiate(meteoroPrefabs, spawnPos, meteoroPrefabs.transform.rotation, transform);
                break; // Ya instanciamos bien, salimos
            }
        }
    }
    // para ver el Gizmo
    void OnDrawGizmos()
    {

        if (areaSpawn == null) return;

        Gizmos.color = Color.green;
        Bounds b = areaSpawn.bounds;

        // Área total
        Gizmos.DrawWireCube(b.center, b.size);

        // Área con margen (la segura)
        Gizmos.color = Color.yellow;
        Vector3 sizeConMargen = new Vector3(
            b.size.x - margen * 2f,
            b.size.y,
            b.size.z - margen * 2f
        );

        Gizmos.DrawWireCube(b.center, sizeConMargen);
    }

    void OnDisable()
    {
        CancelInvoke();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void OnEnable()
    {
        CancelInvoke();
        InvokeRepeating(nameof(SpawnRandomAnimals), startDelay, spawnInterval);
    }
}