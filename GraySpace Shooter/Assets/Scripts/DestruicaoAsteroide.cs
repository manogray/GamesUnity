using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruicaoAsteroide : MonoBehaviour {

	public GameObject explosao;
	public GameObject ExplosaoJogador;
	public GameObject ControladorDeJogo;
	public ControladorDeJogo controleJogoScript;

	void Start (){
		ControladorDeJogo = GameObject.FindWithTag ("ControladorDeJogo");
		if (ControladorDeJogo != null) {
			controleJogoScript = ControladorDeJogo.GetComponent<ControladorDeJogo> ();
		}
	}

	void OnTriggerEnter(Collider qualquerCoisa){
		if (qualquerCoisa.tag != "ZonaDaMorte" && qualquerCoisa.tag != "Asteroide" && qualquerCoisa.tag != "Inimigo") {
			Instantiate (explosao, transform.position, transform.rotation);
			if (qualquerCoisa.tag == "Jogador") {
				Instantiate (ExplosaoJogador, qualquerCoisa.transform.position, qualquerCoisa.transform.rotation);
				controleJogoScript.ExibirGameOver ("Game Over!");
			}
			if (qualquerCoisa.tag == "Tiro") {
				controleJogoScript.AddUmPonto (10);
			}
			Destroy (qualquerCoisa.gameObject);
			Destroy (gameObject);
		}
	}
}
