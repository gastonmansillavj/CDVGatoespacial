using System.Collections;
using UnityEngine;
using TMPro; // Necesario para TextMeshPro

public class EfectoEscritura : MonoBehaviour
{
    private TMP_Text componenteTexto;
    [SerializeField] float velocidadTipeo = 0.05f;

    void Awake()
    {
        componenteTexto = GetComponent<TMP_Text>();
    }

    void Start()
    {
        StartCoroutine(MostrarTexto());
    }

    IEnumerator MostrarTexto()
    {
        // 1. Forzamos la actualización para que TMP calcule cuántos caracteres hay
        componenteTexto.ForceMeshUpdate();
        int totalCaracteres = componenteTexto.textInfo.characterCount;
        
        // 2. Ocultamos todos los caracteres inicialmente
        componenteTexto.maxVisibleCharacters = 0;

        for (int i = 0; i <= totalCaracteres; i++)
        {
            // 3. Vamos revelando uno por uno
            componenteTexto.maxVisibleCharacters = i;
            yield return new WaitForSeconds(velocidadTipeo);
        }
    }
}
