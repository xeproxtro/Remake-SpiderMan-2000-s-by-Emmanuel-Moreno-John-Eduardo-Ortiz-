using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public int puntos = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Recolectado! +" + puntos);
            Destroy(gameObject);
        }
    }
}