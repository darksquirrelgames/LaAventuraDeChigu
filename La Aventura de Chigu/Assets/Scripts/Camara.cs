using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

	[SerializeField] Transform objetivo;
	[SerializeField] float offset = 2f;
	[SerializeField] float suavidadMovimiento = 1f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = objetivo.transform.position.x + offset;
		transform.position = Vector3.Lerp(transform.position, position, suavidadMovimiento*Time.deltaTime);
    }
}
