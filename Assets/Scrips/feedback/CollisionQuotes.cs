using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CollisionQuotes : MonoBehaviour {
    [Header("Referencias")]
    public TextMeshProUGUI textMesh; // Arrastrá acá el objeto "DialogoPopup"
    
    [Header("Configuración")]
    public List<string> quotes;      // Tus frases: "¡Miau!", "¡Cuidado!", etc.
    public float displayTime = 1.5f; // Cuánto tiempo se queda visible

    private Coroutine hideCoroutine;

    // Este método lo conectamos al evento OnHit (Vector2) del script Health
    public void ShowQuote(Vector2 hitPosition) {
        if (quotes.Count == 0 || textMesh == null) return;

        // 1. Elegir frase al azar
        string randomQuote = quotes[Random.Range(0, quotes.Count)];
        textMesh.text = randomQuote;

        // 2. Mostrar el objeto
        textMesh.gameObject.SetActive(true);

        // 3. Reiniciar el temporizador para ocultarlo
        if (hideCoroutine != null) StopCoroutine(hideCoroutine);
        hideCoroutine = StartCoroutine(HideAfterTime());
    }

    private IEnumerator HideAfterTime() {
        yield return new WaitForSeconds(displayTime);
        textMesh.gameObject.SetActive(false);
    }
}
