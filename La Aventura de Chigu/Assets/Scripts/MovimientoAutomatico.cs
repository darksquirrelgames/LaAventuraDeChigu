using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class MovimientoAutomatico : MonoBehaviour {

    [Header ("Configuración")]
    [SerializeField] float velocidadMovimiento;
	[Range (-1,1)]
	[SerializeField] float direccion;
    Rigidbody2D miRigidBody;

	// Use this for initialization
	void Start () {
        miRigidBody = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("Mover", 5f, 1f);
    }
	
	// Update is called once per frame
	void Mover () {
		miRigidBody.velocity = new Vector2(velocidadMovimiento*direccion*Time.deltaTime,0);
	}
}
