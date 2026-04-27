using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable {
    [SerializeField] private ShipData shipData;
    private float currentHealth;

    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnDeath;
    // Nuevo evento para los efectos de feedback (Flash, Knockback, Shake)
    public UnityEvent<Vector2> OnHit; 

    void Start() {
        if (shipData != null) currentHealth = shipData.maxHealth;
    }

    // Firma actualizada para cumplir con la interfaz
    public void TakeDamage(float amount, Vector2 hitPosition) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, shipData.maxHealth);

        OnHealthChanged?.Invoke(currentHealth / shipData.maxHealth);
        
        // Disparamos el feedback pasando la posición del impacto
        OnHit?.Invoke(hitPosition);

        if (currentHealth <= 0) Die();
    }

    private void Die() {
        OnDeath?.Invoke();
    }

    // Método para el Power-up de curación (no necesita posición)
    public void AddHealth(float amount) {
        currentHealth = Mathf.Min(currentHealth + amount, shipData.maxHealth);
        OnHealthChanged?.Invoke(currentHealth / shipData.maxHealth);
    }
}
