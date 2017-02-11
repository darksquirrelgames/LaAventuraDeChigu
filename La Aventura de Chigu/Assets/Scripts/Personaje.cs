using UnityEngine;

public abstract class Personaje : MonoBehaviour {

	[Header ("Configuración del Personaje")]
	[SerializeField] protected float velocidadMovimiento;
	
	protected bool mirandoDerecha;

	public virtual void Start () {
		mirandoDerecha = true;
	}
	
	public void CambiarDireccion () {
		mirandoDerecha = !mirandoDerecha;
		transform.localScale = new Vector3 (transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
	}
}
