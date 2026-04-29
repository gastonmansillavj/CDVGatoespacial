using UnityEngine;
using System.Collections;

public class EmergencyAlarms : MonoBehaviour
{
    [Header("Configuración")]
    [Range(0, 1)] 
    [SerializeField] private float threshold = 0.34f; // Se activa al 33% (última vida si son 3)
    [SerializeField] private Color warningColor = Color.red;
    [SerializeField] private float blinkSpeed = 0.2f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine blinkCoroutine;
    private bool isWarningActive = false;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = Color.white; // O el color base de tu nave
    }

    // Este método se conecta al OnHealthChanged(float) del script Health
    public void CheckHealth(float healthPercentage)
    {
        if (healthPercentage <= threshold && !isWarningActive)
        {
            StartWarning();
        }
        else if (healthPercentage > threshold && isWarningActive)
        {
            StopWarning();
        }
    }

    private void StartWarning()
    {
        isWarningActive = true;
        if (blinkCoroutine != null) StopCoroutine(blinkCoroutine);
        blinkCoroutine = StartCoroutine(BlinkRoutine());
    }

    private void StopWarning()
    {
        isWarningActive = false;
        if (blinkCoroutine != null) StopCoroutine(blinkCoroutine);
        spriteRenderer.color = originalColor; // Vuelve al color normal
    }

    private IEnumerator BlinkRoutine()
    {
        while (isWarningActive)
        {
            spriteRenderer.color = warningColor;
            yield return new WaitForSeconds(blinkSpeed);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
    
    // Si la nave muere, detenemos todo
    void OnDisable() => StopWarning();
}
