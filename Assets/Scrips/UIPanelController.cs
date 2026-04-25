using UnityEngine;

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

    // Métodos para los botones
    public void RestartScene() {
    // ¡Fundamental! Si no reseteas el tiempo aquí, la nueva escena cargará congelada
    Time.timeScale = 1f; 
    
    // Cargamos la escena actual
    UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
    );
}
    public void QuitGame() => Application.Quit();
}
