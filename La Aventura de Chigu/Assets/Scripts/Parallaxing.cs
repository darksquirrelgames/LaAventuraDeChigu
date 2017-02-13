using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	[SerializeField] private Transform [] fondos;	// Arreglo de las imagenes que se van a utilizar para el Parallax
	[SerializeField] float smoothParallax = 1f;		// Valor con el que se van a mover los fondos al hacer el Parallax
	private float [] escalasParallax;				// Proporciones del movimiento de la cámara para mover los fondos
	private Transform camara;						// Referncia a la cámapra principal
	private Vector3 posicionAnteriorCamara;			// Posición de la cámara en el frame anterior

	void Awake(){
		camara = Camera.main.transform;
		
	}

	// Use this for initialization
	void Start () {
		posicionAnteriorCamara = camara.position;
		escalasParallax = new float [fondos.Length];
		for (int i = 0; i < fondos.Length; i++){
			escalasParallax[i] = fondos[i].position.z*-1;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < fondos.Length; i++){
			float parallax = (posicionAnteriorCamara.x - camara.position.x) * escalasParallax[i];
			float posicionXFondo = fondos[i].position.x + parallax;
			Vector3 nuevaPosicionFondo = new Vector3 (posicionXFondo, fondos[i].position.y, fondos[i].position.z);
			fondos[i].position = Vector3.Lerp(fondos[i].position, nuevaPosicionFondo, smoothParallax*Time.deltaTime);
		}
		posicionAnteriorCamara = camara.position;
	}
}
