using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruicaoJogador : MonoBehaviour {

	public GameObject ExplosaoJogador;
	private GameObject ControleJogo;
	private ControladorDeJogo controleJogoScript;

	void Start (){
		ControleJogo = GameObject.FindWithTag ("ControladorDeJogo");
		controleJogoScript = ControleJogo.GetComponent<ControladorDeJogo> ();
	}

	void OnTriggerEnter (Collider algo){
		if(algo.tag == "Jogador"){
			Instantiate (ExplosaoJogador, algo.transform.position, algo.transform.rotation);
			controleJogoScript.ExibirGameOver ("Game Over!");
			Destroy (algo.gameObject);
			Destroy (gameObject);
		}
	}
}
