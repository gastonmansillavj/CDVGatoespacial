using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSeleccion : MonoBehaviour {
    // Ya no necesitamos el ScriptableObject si usamos PlayerPrefs
    
    public void SeleccionarPerro() {
        PlayerPrefs.SetInt("PersonajeElegido", 0); // 0 para Perro
        PlayerPrefs.Save(); // Fuerza el guardado en el navegador
        SceneManager.LoadScene("Narrativa");
    }

    public void SeleccionarGato() {
        PlayerPrefs.SetInt("PersonajeElegido", 1); // 1 para Gato
        PlayerPrefs.Save();
        SceneManager.LoadScene("Narrativa");
    }
}
