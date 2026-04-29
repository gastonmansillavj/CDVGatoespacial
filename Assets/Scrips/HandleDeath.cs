using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    // Esta función la usaremos para el Player
    public void DeactivateObject()
    {
        // Desactiva el movimiento y la visual, pero el objeto sigue existiendo
        // para que no rompa las referencias de la cámara o menús.
        gameObject.SetActive(false);
    }

    // Esta función la usaremos para los Meteoros y fragmentos
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
