using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruicaoExplosao : MonoBehaviour {

	public float tempoDeVida;

	void Start (){
		Destroy (gameObject,tempoDeVida);
	}
}
