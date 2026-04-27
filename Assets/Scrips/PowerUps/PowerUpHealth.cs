using UnityEngine;

public class PowerUpHealth : PowerUp {
    public float healAmount =1f;

    public override void Activate(GameObject player) {
        if (player.TryGetComponent(out Health health)) {
            health.AddHealth(healAmount);
            Debug.Log("Vida recargada: " + healAmount);
        }
    }
}
