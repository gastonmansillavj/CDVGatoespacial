using UnityEngine;

public class PlayerSpawner : MonoBehaviour 
{
    [Header("Prefabs de Personajes")]
    public GameObject prefabPerro;
    public GameObject prefabGato;

    void Awake() 
    {
        // 1. Buscamos el número guardado (0 = Perro, 1 = Gato)
        // El ", 0" es por si no hay nada guardado todavía (el perro por defecto)
        int eleccion = PlayerPrefs.GetInt("PersonajeElegido", 0);

        // 2. Instanciamos según el número
        if (eleccion == 0) 
        {
            if(prefabPerro != null) Instantiate(prefabPerro, transform.position, transform.rotation);
        } 
        else 
        {
            if(prefabGato != null) Instantiate(prefabGato, transform.position, transform.rotation);
        }
    }
}
