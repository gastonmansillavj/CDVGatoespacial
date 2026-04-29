using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class UIPanelController : MonoBehaviour {
    [SerializeField] private GameObject panelObject;

    public void ShowPanel(bool pauseTime) {
        panelObject.SetActive(true);
        if (pauseTime) Time.timeScale = 0f;
    }

    public void HidePanel() {
        panelObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartScene() {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // --- NUEVO MÉTODO PARA EL MENÚ ---
    public void GoToMainMenu(string sceneName) {
        Time.timeScale = 1f; // ¡Importante! Resetear el tiempo antes de irse
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() => Application.Quit();
}
