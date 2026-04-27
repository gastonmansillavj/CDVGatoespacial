using UnityEngine;

public class PowerUpDrill : PowerUp {
   public override void Activate(GameObject player) {
    // Ahora el script está en el objeto principal (player)
    DrillController drill = player.GetComponent<DrillController>();
    if (drill != null) {
        drill.StartDrilling(duration);
    }
}

}
