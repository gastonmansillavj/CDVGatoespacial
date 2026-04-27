using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de nivel

public class LevelGoal : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Nombre de la escena a la que queremos ir. Si se deja vacío, cargará la siguiente en la lista.")]
    public string nextLevelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si lo que tocó el final de nivel es el Jugador
        if (other.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        // Aseguramos que el tiempo vuelva a la normalidad por si venimos de una pausa
        Time.timeScale = 1f;

        if (!string.IsNullOrEmpty(nextLevelName))
        {
            // Carga la escena por el nombre que escribas en el Inspector
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            // Si no escribiste nombre, carga la siguiente escena en el orden de Build Settings
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            
            // Verificamos si existe una siguiente escena para evitar errores
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.LogWarning("¡No hay más niveles en el Build Settings!");
            }
        }
    }
}
