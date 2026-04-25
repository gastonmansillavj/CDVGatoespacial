using UnityEngine;
using UnityEngine.InputSystem; // ¡Importante!

public class PlayerInput : MonoBehaviour {
    public bool LeftPropulsor { get; private set; }
    public bool RightPropulsor { get; private set; }

    void Update() {
        // En el nuevo sistema se accede a través del teclado actual
        if (Keyboard.current != null) {
            LeftPropulsor = Keyboard.current.aKey.isPressed;
            RightPropulsor = Keyboard.current.dKey.isPressed;
        }
    }
}
