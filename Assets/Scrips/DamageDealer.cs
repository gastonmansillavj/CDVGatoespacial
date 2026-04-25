using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [Header("Configuración de Daño")]
    public float damage = 20f;
    public bool destroyOnHit = false; // ¿Se rompe el proyectil/meteoro al chocar?

    [Header("Efectos (Opcional)")]
    public EffectData statusEffect; // Si arrastras un ScriptableObject de hielo, lo aplicará

    private void OnCollisionEnter2D(Collision2D collision) {
        ApplyDamage(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Por si usas Triggers (como el agujero negro o un láser)
        ApplyDamage(other.gameObject);
    }

    private void ApplyDamage(GameObject target) {
        // 1. Intentar hacer daño
        if (target.TryGetComponent(out IDamageable damageable)) {
            damageable.TakeDamage(damage);
        }

        // 2. Intentar aplicar estado (Hielo, etc.)
        if (statusEffect != null && target.TryGetComponent(out EffectReceiver receiver)) {
            receiver.ApplyEffect(statusEffect);
        }

        // 3. Auto-destrucción (si aplica)
        if (destroyOnHit) {
            Destroy(gameObject);
        }
    }
}
