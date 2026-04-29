using UnityEngine;
using System.Collections.Generic;

public class HealthVisuals : MonoBehaviour
{
   [Header("Sprites por Vida")]
    [Tooltip("Orden: 0 vidas, 1 vida, 2 vidas, 3 vidas")]
    [SerializeField] private List<Sprite> spritesPorVida;

    [Header("Config")]
    [SerializeField] private int maxLives = 3;

    private SpriteRenderer spriteRenderer;
    private int lastLives = -1; // para detectar cambios

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // ESTE es el método que vas a conectar al evento OnHealthChanged(float)
    public void UpdateVisuals(float healthPercentage)
    {
        if (spritesPorVida == null || spritesPorVida.Count == 0) return;
        if (maxLives <= 0) return;

        // Convertimos porcentaje → vidas enteras
        int currentLives = Mathf.CeilToInt(healthPercentage * maxLives);

        // Clamp por seguridad
        currentLives = Mathf.Clamp(currentLives, 0, maxLives);

        // Solo actualiza si cambió la cantidad de vidas
        if (currentLives == lastLives) return;

        lastLives = currentLives;

        // Ajustamos índice a la lista
        int index = Mathf.Clamp(currentLives, 0, spritesPorVida.Count - 1);

        spriteRenderer.sprite = spritesPorVida[index];
    }
}
