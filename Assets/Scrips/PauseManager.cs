using UnityEngine;
using UnityEngine.InputSystem; // ¡Asegúrate de agregar esta línea!

public class PauseManager : MonoBehaviour {
    private UIPanelController panelController;
    private bool isPaused = false;

    void Awake() {
        panelController = GetComponent<UIPanelController>();
    }

    void Update() {
        // Usamos el nuevo Input System para detectar la tecla Escape
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame) {
            if (isPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Pause() {
        isPaused = true;
        panelController.ShowPanel(true);
    }

    public void Resume() {
        isPaused = false;
        panelController.HidePanel();
    }
}
