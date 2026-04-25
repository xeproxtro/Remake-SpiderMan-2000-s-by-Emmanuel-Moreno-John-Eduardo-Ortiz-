using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2.0f;
    
    private Vector3 destino;

    void Start()
    {
        // Iniciamos el movimiento hacia el punto B
        if (puntoB != null)
        {
            destino = puntoB.position;
        }
    }

    void FixedUpdate()
    {
        if (puntoA == null || puntoB == null) return;

        // Movemos la plataforma físicamente
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.fixedDeltaTime);

        // Si llegamos al destino, cambiamos al otro punto
        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            destino = (destino == puntoA.position) ? puntoB.position : puntoA.position;
        }
    }

    // --- DETECCIÓN DE JUGADOR ---

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra tiene el Tag "Player"
        if (other.CompareTag("Player"))
        {
            // Hacemos que el jugador sea hijo de la plataforma para que se mueva con ella
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Al salir de la plataforma, el jugador deja de ser hijo de esta
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}