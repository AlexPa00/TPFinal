using UnityEngine;

public class RecogerBasura : MonoBehaviour
{
    private GameObject objetoRecogido;

    void Update()
    {
        // Verificar si hay toques en la pantalla
        if (Input.touchCount > 0)
        {
            // Obtener el primer toque
            Touch touch = Input.GetTouch(0);

            // Verificar si es el inicio del toque
            if (touch.phase == TouchPhase.Began)
            {
                // Lanzar un rayo desde la posición del toque en la pantalla
                Ray rayo = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Verificar si el rayo impacta con un objeto llamado "basura"
                if (Physics.Raycast(rayo, out hit) && hit.collider.CompareTag("basura"))
                {
                    // Recoger el objeto
                    objetoRecogido = hit.collider.gameObject;

                    // Desactivar la gravedad y la física para el objeto recogido
                    objetoRecogido.GetComponent<Rigidbody>().useGravity = false;
                    objetoRecogido.GetComponent<Rigidbody>().isKinematic = true;

                    if (Physics.Raycast(rayo, out hit) && hit.collider.CompareTag("basura"))
{
    Debug.Log("Objeto de basura detectado");
    // Resto del código...
}

                    // Opcional: Hacer que el objeto recogido sea hijo de otro objeto (como la mano del jugador)
                    // objetoRecogido.transform.SetParent(HandPoint.transform);
                }
            }
            // Verificar si es el final del toque
            else if (touch.phase == TouchPhase.Ended)
            {
                // Soltar el objeto recogido
                if (objetoRecogido != null)
                {
                    objetoRecogido.GetComponent<Rigidbody>().useGravity = true;
                    objetoRecogido.GetComponent<Rigidbody>().isKinematic = false;

                    // Opcional: Deshacer la relación de padre-hijo
                    // objetoRecogido.transform.SetParent(null);

                    // Limpiar la referencia al objeto recogido
                    objetoRecogido = null;
                }
            }
        }
    }
}



