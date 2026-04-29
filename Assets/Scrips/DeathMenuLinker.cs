using UnityEngine;

public class DeathMenuLinker : MonoBehaviour
{
    void Start()
    {
        // 1. Buscamos el Canvas (que siempre está activo)
        Canvas canvas = FindFirstObjectByType<Canvas>();

        if (canvas != null)
        {
            // 2. Buscamos entre sus hijos (incluyendo desactivados)
            UIPanelController[] todosLosPaneles = canvas.GetComponentsInChildren<UIPanelController>(true);

            foreach (UIPanelController panel in todosLosPaneles)
            {
                // 3. Filtramos por el nombre del objeto para encontrar el de Muerte
                if (panel.gameObject.name == "MenuMuerte")
                {
                    GetComponent<Health>().OnDeath.AddListener(() => panel.ShowPanel(true));
                    Debug.Log("Conectado con éxito al menú: " + panel.gameObject.name);
                    break; 
                }
            }
        }
    }
}