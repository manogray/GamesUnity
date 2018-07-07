using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour {
	private bool resposta;

	void Start (){
		resposta = false;
	}

	void OnTriggerEnter (Collider algo){
		if (algo.tag == "Jogador") {
			resposta = true;
		}
	}

	bool NaMira(){
		return resposta;
	}

}