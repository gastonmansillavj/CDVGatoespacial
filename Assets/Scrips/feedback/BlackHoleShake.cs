using UnityEngine;

public class BlackHoleShake : MonoBehaviour {
    [SerializeField] private float intensityInside = 1.5f;
    [SerializeField] private float frequencyInside = 10f; // Nueva variable para la vibración rápida
    private CameraShakeSimple cameraShake;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (cameraShake == null) {
                cameraShake = other.GetComponent<CameraShakeSimple>();
            }

            if (cameraShake != null) {
                // USAMOS las variables aquí para que desaparezca la advertencia
                cameraShake.SetConstantShake(intensityInside, frequencyInside);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && cameraShake != null) {
            cameraShake.SetConstantShake(0f, 0f);
            cameraShake = null;
        }
    }
}
