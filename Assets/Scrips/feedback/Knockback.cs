using UnityEngine;

public class Knockback : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField] private float thrust = 5f;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    public void ApplyKnockback(Vector2 collisionPoint) {
        // 1. Matamos toda la velocidad actual para que no atraviese el objeto
        // Esto hace que el choque se sienta "en seco"
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f; // También frenamos la rotación para más control

        // 2. Calculamos dirección desde el punto de choque hacia nosotros
        Vector2 direction = ((Vector2)transform.position - collisionPoint).normalized;

        // 3. Aplicamos el empuje limpio desde velocidad cero
        rb.AddForce(direction * thrust, ForceMode2D.Impulse);
    }
}
