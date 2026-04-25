using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Grados por segundo. Positivo: Izquierda, Negativo: Derecha")]
    public float rotationSpeed = 50f;

    [Tooltip("Si es True, rotará de forma aleatoria al empezar (ideal para meteoros)")]
    public bool randomStartRotation = false;

    void Start()
    {
        if (randomStartRotation)
        {
            // Le da una rotación inicial al azar para que no todos se vean iguales
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        }
    }

    void Update()
    {
        // Rota en el eje Z (el eje de rotación en juegos 2D)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
