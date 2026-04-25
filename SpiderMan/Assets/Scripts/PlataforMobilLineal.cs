using UnityEngine;

public class PlataforMobilLineal: MonoBehaviour
{
    [Header("Configuración")]
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2.0f;
    
    private bool haLlegado = false;

    void Start()
    {
        // Colocamos la plataforma en el punto inicial al empezar
        if (puntoA != null)
        {
            transform.position = puntoA.position;
        }
    }

    void FixedUpdate()
    {
        // Si ya llegó al final o falta algún punto, no hace nada
        if (haLlegado || puntoA == null || puntoB == null) return;

        // Mover hacia el punto B
        transform.position = Vector3.MoveTowards(transform.position, puntoB.position, velocidad * Time.fixedDeltaTime);

        // Verificar si ya alcanzó la posición del Punto B
        if (Vector3.Distance(transform.position, puntoB.position) < 0.01f)
        {
            haLlegado = true;
            Debug.Log("Plataforma llegó a su destino final.");
        }
    }

    // Mantener al jugador sobre la plataforma
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
