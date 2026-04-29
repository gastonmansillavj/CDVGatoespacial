using UnityEngine;
using System.Collections.Generic;

public class FragmentOnDeath : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private List<GameObject> fragmentPrefabs;
    [SerializeField] private float explosionForce = 5f;  
    [SerializeField] private float lifetime = 3f;

    public void SpawnFragments()
    {
        if (fragmentPrefabs == null || fragmentPrefabs.Count == 0) return;

        // Recorre TODOS los fragmentos de la lista
        foreach (GameObject prefab in fragmentPrefabs)
        {
            if (prefab == null) continue;

            GameObject nuevoFragmento = Instantiate(prefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = nuevoFragmento.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 direccionAleatoria = Random.insideUnitCircle.normalized;

                rb.linearVelocity = direccionAleatoria * explosionForce;
                rb.angularVelocity = Random.Range(-180f, 180f);
            }

            Destroy(nuevoFragmento, lifetime);
        }
    }
}