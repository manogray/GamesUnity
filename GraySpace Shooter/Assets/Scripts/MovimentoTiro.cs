using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoTiro : MonoBehaviour {

	private Rigidbody CorpoTiro;

	public float Velocidade;

	void Start (){
		CorpoTiro = GetComponent<Rigidbody> ();
		CorpoTiro.velocity = transform.forward * Velocidade;
	}
}
