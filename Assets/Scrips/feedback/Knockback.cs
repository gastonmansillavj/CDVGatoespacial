using UnityEngine;

public class Knockback : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField] private float thrust = 5f;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    public void ApplyKnockback(Vector2 collisionPoint) {
        // Calculamos dirección desde el punto de choque hacia nosotros
        Vector2 direction = ((Vector2)transform.position - collisionPoint).normalized;
        rb.AddForce(direction * thrust, ForceMode2D.Impulse);
    }
}
