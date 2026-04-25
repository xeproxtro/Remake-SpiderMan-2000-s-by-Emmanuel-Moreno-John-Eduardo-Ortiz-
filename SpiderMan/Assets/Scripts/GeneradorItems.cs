using UnityEngine;

public class GeneradorItems : MonoBehaviour
{
    public GameObject prefabItem;
    public float tiempoEntreSpawn = 2f;
    private float temporizador;
    
    // Variable para rastrear el item actual en la escena
    private GameObject itemActual;

    void Start()
    {
        SpawnearItem();
        temporizador = tiempoEntreSpawn;
    }

    void Update()
    {
        // Solo descontamos tiempo si NO hay un ítem en la escena
        if (itemActual == null)
        {
            temporizador -= Time.deltaTime;

            if (temporizador <= 0f)
            {
                SpawnearItem();
                temporizador = tiempoEntreSpawn;
            }
        }
    }

    void SpawnearItem()
    {
        // Guardamos la referencia del objeto creado en 'itemActual'
        itemActual = Instantiate(prefabItem, transform.position, Quaternion.identity);
    }
}