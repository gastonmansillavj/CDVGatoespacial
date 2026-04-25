using UnityEngine;

public class BlackHole : MonoBehaviour {
    [Header("Configuración")]
    public float attractionForce = 8f; // Debe ser menor a la fuerza de tu nave
    public float damagePerSecond = 5f; // Opcional: daño por estar dentro

    private void OnTriggerStay2D(Collider2D other) {
        // Buscamos si lo que entró tiene física
        if (other.TryGetComponent(out Rigidbody2D rb)) {
            // 1. Calcular la dirección hacia el centro del agujero negro
            Vector2 direction = (Vector2)transform.position - rb.position;
            
            // 2. Aplicar la fuerza de atracción
            // Usamos ForceMode2D.Force para que sea constante
            rb.AddForce(direction.normalized * attractionForce);

            // 3. Opcional: Aplicar daño modularmente si tiene salud
            if (other.TryGetComponent(out IDamageable health)) {
                health.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}
