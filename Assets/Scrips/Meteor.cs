using UnityEngine;

public class Meteor : MonoBehaviour {
    public float damage = 20f;
    public EffectData statusEffect; // Si está vacío, no aplica efecto

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable)) {
            damageable.TakeDamage(damage, transform.position);
        }

        if (statusEffect != null && collision.gameObject.TryGetComponent(out EffectReceiver receiver)) {
            receiver.ApplyEffect(statusEffect);
        }
    }
}
