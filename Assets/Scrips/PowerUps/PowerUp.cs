using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
    [SerializeField] protected float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Activate(other.gameObject);
            Destroy(gameObject); // El item desaparece al recogerlo
        }
    }

    public abstract void Activate(GameObject player);
}
