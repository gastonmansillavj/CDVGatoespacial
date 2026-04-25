using UnityEngine;

public class ShipMovement : MonoBehaviour {
    public ShipData data; 
    public GameObject motorIzquierdo; // Arrastra el objeto del fuego izquierdo
    public GameObject motorDerecho;   // Arrastra el objeto del fuego derecho

    private Rigidbody2D rb;
    private PlayerInput input;
    public float currentSpeedModifier = 1f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }

    void FixedUpdate() {
        float force = data.thrustForce * currentSpeedModifier;

        // LÓGICA DE MOTORES VISUALES
        // Si presiona A (Izquierda), se activa el motor IZQUIERDO para rotar a la DERECHA
        // Si presiona D (Derecha), se activa el motor DERECHO para rotar a la IZQUIERDA
        // Si presiona AMBOS, se activan los DOS
        
        motorIzquierdo.SetActive(input.LeftPropulsor);
        motorDerecho.SetActive(input.RightPropulsor);

        // LÓGICA DE MOVIMIENTO (Física)
        if (input.LeftPropulsor && input.RightPropulsor) {
            rb.AddRelativeForce(Vector2.up * force);
        } 
        else if (input.LeftPropulsor) {
            rb.AddTorque(-data.rotationTorque);
        } 
        else if (input.RightPropulsor) {
            rb.AddTorque(data.rotationTorque);
        }
    }
}
