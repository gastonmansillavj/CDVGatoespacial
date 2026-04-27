using UnityEngine;
using System.Collections;

public class DamageFlash : MonoBehaviour {
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float duration = 0.15f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Awake() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Flash() {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine() {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = originalColor;
    }
}
