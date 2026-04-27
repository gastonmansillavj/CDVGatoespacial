using System;
using UnityEngine;

public class DrillTrigger : MonoBehaviour {
    private DrillController controller;

    void Start() {
        controller = GetComponentInParent<DrillController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (controller.targetsToDestroy.Contains(other.tag)) {
            
            if (other.TryGetComponent(out IDamageable health)) {
                controller.OnDrillHit(health);
            }
        }
    }
}
