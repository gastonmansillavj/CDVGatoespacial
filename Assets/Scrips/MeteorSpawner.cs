using UnityEngine;

public class MeteorSpawner : MonoBehaviour {
    [Header("Referencias")]
    public GameObject[] meteorPrefabs; // Arrastra tus prefabs de meteoros aquí
    public Transform player;

    [Header("Configuración")]
    public float spawnRadius = 15f;    // Distancia fuera de la cámara
    public float spawnRate = 2f;      // Cada cuántos segundos sale uno
    public float minSpeed = 2f;
    public float maxSpeed = 5f;

    void Start() {
        // Ejecuta la función Spawn cada 'spawnRate' segundos
        InvokeRepeating("SpawnMeteor", 2f, spawnRate);
    }

    void SpawnMeteor() {
        if (player == null) return;

        // 1. Obtener una posición aleatoria en un círculo
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = player.position + (Vector3)(randomDirection * spawnRadius);

        // 2. Instanciar el meteoro
        GameObject meteor = Instantiate(meteorPrefabs[Random.Range(0, meteorPrefabs.Length)], spawnPosition, Quaternion.identity);

        // 3. Hacer que se mueva hacia la posición actual del jugador (con un poco de error para que no sea puntería perfecta)
        Rigidbody2D rb = meteor.GetComponent<Rigidbody2D>();
        if (rb != null) {
            Vector2 targetDirection = (player.position - spawnPosition).normalized;
            // Añadimos un poco de variación para que no todos vayan directo al centro
            targetDirection += new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            
            float speed = Random.Range(minSpeed, maxSpeed);
            rb.linearVelocity = targetDirection * speed; // Unity 6 usa linearVelocity
            
            // Opcional: que el meteoro rote un poco sobre sí mismo
            rb.AddTorque(Random.Range(-5f, 5f), ForceMode2D.Impulse);
        }
    }
}
