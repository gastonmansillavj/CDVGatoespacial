using UnityEngine;
using UnityEngine.UI; // Necesario para el componente Image

public class HealthBarUI : MonoBehaviour {
    [SerializeField] private Image healthFillImage; // La imagen de la barra (tipo Filled)

    // Este método lo llamará el evento del script Health
    public void UpdateHealthBar(float fraction) {
        if (healthFillImage != null) {
            healthFillImage.fillAmount = fraction;
        }
    }
}
