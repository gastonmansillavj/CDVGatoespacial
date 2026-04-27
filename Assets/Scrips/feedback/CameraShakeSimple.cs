using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraShakeSimple : MonoBehaviour {
    private CinemachineBasicMultiChannelPerlin noise;
    [SerializeField] private float hitIntensity = 5f;
    [SerializeField] private float hitTime = 0.2f;

    void Start() {
        var vcam = FindFirstObjectByType<CinemachineCamera>();
        if (vcam != null) noise = vcam.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Para el agujero negro (temblor constante)
    public void SetConstantShake(float intensity, float frequency = 2f) {
    if (noise != null) {
        noise.AmplitudeGain = intensity;
        noise.FrequencyGain = (intensity > 0) ? frequency : 0f; // Si hay intensidad, sube la frecuencia
    }
}

    // Para los choques (ráfaga corta)
    public void Shake() {
        if (noise == null) return;
        StopAllCoroutines();
        StartCoroutine(ProcessShake());
    }

    private IEnumerator ProcessShake() {
        noise.AmplitudeGain = hitIntensity;
        yield return new WaitForSeconds(hitTime);
        noise.AmplitudeGain = 0f;
    }
}
