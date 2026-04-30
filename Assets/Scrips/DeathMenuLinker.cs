using UnityEngine;

public class DeathMenuLinker : MonoBehaviour
{
    void Start()
    {
        // 1. Buscamos TODOS los Canvas que hay en la escena
        Canvas[] todosLosCanvas = FindObjectsByType<Canvas>(FindObjectsSortMode.None);
        Canvas canvasPrincipal = null;

        // 2. Buscamos cuál es el Canvas principal (el que no es World Space)
        foreach (Canvas c in todosLosCanvas)
        {
            if (c.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                canvasPrincipal = c;
                break;
            }
        }

        if (canvasPrincipal != null)
        {
            // 3. Buscamos el MenuMuerte dentro de ese Canvas principal
            UIPanelController[] paneles = canvasPrincipal.GetComponentsInChildren<UIPanelController>(true);

            foreach (UIPanelController p in paneles)
            {
                if (p.gameObject.name == "MenuMuerte")
                {
                    GetComponent<Health>().OnDeath.AddListener(() => p.ShowPanel(true));
                    Debug.Log("Linker: Conectado al Menú de Muerte del Canvas Principal");
                    break;
                }
            }
        }
    }
}
