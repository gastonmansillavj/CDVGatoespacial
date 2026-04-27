using UnityEngine;
using System.Collections.Generic;

public class Shield : MonoBehaviour {
    [Header("Configuración")]
    public List<string> protectFromTags; 
    [SerializeField] private GameObject visualSprite;
    
    private Knockback shipKnockback;

    void Awake() {
        // Buscamos el componente Knockback en el padre (la Nave)
        shipKnockback = GetComponentInParent<Knockback>();
        DeactivateShield();
    }

    public void ActivateShield() {
        visualSprite.SetActive(true);
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Si el objeto tiene un tag que debemos bloquear
        if (protectFromTags.Contains(other.tag)) {
            // 1. Aplicamos el Knockback a la nave usando la posición del enemigo
            if (shipKnockback != null) {
                shipKnockback.ApplyKnockback(other.transform.position);
            }

            // 2. Desactivamos el escudo (un solo uso)
            DeactivateShield();

            // 3. Opcional: Destruir el meteoro para que no atraviese la nave
            Destroy(other.gameObject);
        }
    }

    private void DeactivateShield() {
        visualSprite.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
    }
}
