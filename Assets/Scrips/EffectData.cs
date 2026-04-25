using UnityEngine;

[CreateAssetMenu(fileName = "NewEffect", menuName = "SpaceGame/Effect Data")]
public class EffectData : ScriptableObject {
    public float speedMultiplier = 0.5f;
    public float duration = 3f;
    public Color effectColor = Color.blue; // Para dar feedback visual
}
