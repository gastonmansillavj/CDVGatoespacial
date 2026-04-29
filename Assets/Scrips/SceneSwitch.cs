using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    public void IniciarJuego()
    {
        SceneManager.LoadScene("SeleccionPersonaje");
    }
    public void IrOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }
    public void IrCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
