using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerCosas : MonoBehaviour
{
private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó tiene el tag "basura"
        if (other.CompareTag("basura"))
        {
            // Destruir el objeto de basura
            Destroy(other.gameObject);
        }
    }
}