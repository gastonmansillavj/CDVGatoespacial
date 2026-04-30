using UnityEngine;
using UnityEngine.SceneManagement; // Obligatorio para cambiar escenas

public class SceneChanger : MonoBehaviour
{
    [Tooltip("Escribí el nombre de la escena. SI LO DEJÁS VACÍO, cargará la siguiente en el Build Settings.")]
    public string sceneName;

    public void ChangeScene()
    {
        // Siempre reseteamos el tiempo por si venimos de una pausa
        Time.timeScale = 1f;

        // 1. Si escribiste un nombre, vamos a esa escena
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        // 2. Si NO escribiste nada, vamos a la siguiente en la lista
        else
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // Verificamos si existe una escena después de esta
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.LogWarning("¡No hay más escenas en el Build Settings! Volviendo al inicio...");
                SceneManager.LoadScene(0); // Opcional: vuelve al menú principal (índice 0)
            }
        }
    }
}
