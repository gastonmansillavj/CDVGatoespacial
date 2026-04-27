using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrillController : MonoBehaviour {
    [Header("Referencias")]
    [SerializeField] private GameObject visualDrillObject; // Arrastra aquí el hijo "Taladro"

    [Header("Configuración")]
    public float drillDamage = 100f;
    public int maxUses = 3; 
    public List<string> targetsToDestroy;

    private int currentUses;
    private Collider2D drillCollider;

    void Awake() {
        // Obtenemos el collider del objeto HIJO
        if (visualDrillObject != null) {
            drillCollider = visualDrillObject.GetComponent<Collider2D>();
            visualDrillObject.SetActive(false); // Aseguramos que empiece apagado
        }
    }

    public void StartDrilling(float duration) {
        // Ahora esto funciona porque la NAVE está activa
        currentUses = 0;
        StopAllCoroutines();
        StartCoroutine(DrillRoutine(duration));
    }

    private IEnumerator DrillRoutine(float duration) {
        visualDrillObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        visualDrillObject.SetActive(false);
    }

    // Este método lo llamaremos desde un pequeño script en el hijo
    public void OnDrillHit(IDamageable health) {
        health.TakeDamage(drillDamage, transform.position);
        currentUses++;

        if (currentUses >= maxUses) {
            visualDrillObject.SetActive(false);
            StopAllCoroutines();
        }
    }
}
