using UnityEngine;
using System.Collections;

public class EffectReceiver : MonoBehaviour {public void ApplyEffect(EffectData effect) {
    StopAllCoroutines();
    StartCoroutine(ApplyRoutine(effect));
}

IEnumerator ApplyRoutine(EffectData effect) {
    var move = GetComponent<ShipMovement>();
    move.currentSpeedModifier = effect.speedMultiplier;
    
    // Feedback visual opcional
    GetComponent<SpriteRenderer>().color = effect.effectColor; 

    yield return new WaitForSeconds(effect.duration);

    move.currentSpeedModifier = 1f;
    GetComponent<SpriteRenderer>().color = Color.white;
}

}
