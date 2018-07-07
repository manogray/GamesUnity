using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoAsteroide : MonoBehaviour {

	public float tombo;
	public float Velocidade;
	private Rigidbody CorpoAsteroide;
	private float AlturaMinima, AlturaMaxima;

	void Start (){
		CorpoAsteroide = GetComponent<Rigidbody> ();
		CorpoAsteroide.angularVelocity = Random.insideUnitSphere * tombo;
		CorpoAsteroide.velocity = -transform.forward * Velocidade;
		AlturaMinima = -10.44f;
		AlturaMaxima = 10.44f;
	}

	void FixedUpdate (){
		CorpoAsteroide.position = new Vector3 (0.0f,Mathf.Clamp(CorpoAsteroide.position.y,AlturaMinima,AlturaMaxima),CorpoAsteroide.position.z);
	}
}
