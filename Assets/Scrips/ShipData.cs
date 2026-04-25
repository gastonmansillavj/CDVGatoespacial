using UnityEngine;

[CreateAssetMenu(fileName = "NewShipData", menuName = "SpaceGame/Ship Data")]
public class ShipData : ScriptableObject {
    public float thrustForce = 15f;
    public float rotationTorque = 10f;
    public float maxHealth = 100f;
}
