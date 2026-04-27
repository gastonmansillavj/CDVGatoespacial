using UnityEngine;

public class BlackHole : MonoBehaviour {
    [Header("Configuración de Atracción")]
    public float attractionForce = 8f; 

    [Header("Configuración de Lentitud")]
    [Range(0, 1)] 
    public float slowMultiplier = 0.4f; // 0.4 significa que la nave tendrá el 40% de su fuerza

    private void OnTriggerStay2D(Collider2D other) {
        // 1. Atracción Física (Lo que ya teníamos)
        if (other.TryGetComponent(out Rigidbody2D rb)) {
            Vector2 direction = (Vector2)transform.position - rb.position;
            rb.AddForce(direction.normalized * attractionForce);
        }

        // 2. Reducción de Velocidad (NUEVO)
        // Buscamos el script de movimiento de la nave
        if (other.TryGetComponent(out ShipMovement ship)) {
            ship.currentSpeedModifier = slowMultiplier;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // 3. Restaurar Velocidad al salir
        if (other.TryGetComponent(out ShipMovement ship)) {
            ship.currentSpeedModifier = 1f;
        }
    }
}
