using UnityEngine;
using Unity.Cinemachine; // Para Unity 6

public class CameraFollowPlayer : MonoBehaviour 
{
    void Start() 
    {
        // Buscamos al jugador por el Tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null) 
        {
            // Le decimos a la cámara que lo siga
            GetComponent<CinemachineCamera>().Target.TrackingTarget = player.transform;
        }
    }
}
