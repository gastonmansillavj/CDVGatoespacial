using UnityEngine;

public class PlayerSpawner : MonoBehaviour 
{
    public DatosSeleccion memoria;

    void Awake() 
    {
        if (memoria != null && memoria.prefabElegido != null) 
        {
            // Crea al personaje elegido en la posición de este Spawner
            Instantiate(memoria.prefabElegido, transform.position, transform.rotation);
        }
        else 
        {
            Debug.LogError("¡No hay un personaje elegido en la memoria!");
        }
    }
}
