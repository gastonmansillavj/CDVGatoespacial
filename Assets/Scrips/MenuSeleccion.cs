using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSeleccion : MonoBehaviour 
{
    public DatosSeleccion memoria; 
    public GameObject prefabPerro;
    public GameObject prefabGato;

    public void SeleccionarPerro() 
    {
        memoria.prefabElegido = prefabPerro;
        CargarNivel();
    }

    public void SeleccionarGato() 
    {
        memoria.prefabElegido = prefabGato;
        CargarNivel();
    }

    private void CargarNivel() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel1"); 
    }
}
