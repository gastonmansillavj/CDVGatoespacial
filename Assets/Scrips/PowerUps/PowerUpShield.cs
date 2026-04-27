using UnityEngine;

public class PowerUpShield : PowerUp {
    public override void Activate(GameObject player) {
        // Buscamos el script Shield en los hijos (incluso si está desactivado)
        Shield shield = player.GetComponentInChildren<Shield>(true);
        if (shield != null) {
            shield.ActivateShield();
            Debug.Log("Escudo activado");
        }
    }
}
