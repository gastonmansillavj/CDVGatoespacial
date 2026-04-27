using UnityEngine;

public class CanvasDisable : MonoBehaviour
{
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
