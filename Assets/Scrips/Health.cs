using UnityEngine;
using UnityEngine.Events; // Para usar UnityEvents

public class Health : MonoBehaviour, IDamageable {
    [SerializeField] private ShipData shipData; // Usamos tu ScriptableObject
    private float currentHealth;

    // Eventos para la UI y efectos
    // El float es para pasar el porcentaje (0 a 1)
    public UnityEvent<float> OnHealthChanged; 
    public UnityEvent OnDeath;

    void Start() {
        if (shipData != null) {
            currentHealth = shipData.maxHealth;
        }
    }

    public void TakeDamage(float amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, shipData.maxHealth);

        // Notificamos a quien esté escuchando (ej. la UI)
        float percentage = currentHealth / shipData.maxHealth;
        OnHealthChanged?.Invoke(percentage);

        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        OnDeath?.Invoke();
        Debug.Log(gameObject.name + " explotó.");
        // Aquí podrías instanciar partículas o desactivar el objeto
    }
}
