using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]

public class ControladorVr : MonoBehaviour
{
    private CharacterController ControladorDePersona;
    private Vector3 MovimientoEnDireccion = Vector3.zero;           
    private Vector2 Entrada;

    private CollisionFlags BanderasDeColisicion;

    public float FuerzaAlTocarElSuelo;
    public float MultiplicarGravedad;   

    
    
    void Start()
    {
    
        ControladorDePersona = GetComponent<CharacterController>();   

    }

    
    void FixedUpdate()
    {
        Vector3 MovimientoDeseado = transform.forward * Entrada.y + transform.right * Entrada.x;
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, ControladorDePersona.radius, Vector3.down, out hitInfo, 
        ControladorDePersona.height / 2f, Physics.AllLayers,QueryTriggerInteraction.Ignore);    

        MovimientoDeseado = Vector3.ProjectOnPlane(MovimientoDeseado, hitInfo.normal).normalized;    

        if (ControladorDePersona.isGrounded)
        {
            MovimientoEnDireccion.y = -FuerzaAlTocarElSuelo;
        }
        else
        {
            MovimientoEnDireccion  +=  Physics.gravity * MultiplicarGravedad * Time.fixedDeltaTime;
        }

        BanderasDeColisicion = ControladorDePersona.Move(MovimientoEnDireccion * Time.fixedDeltaTime);

    }
}

