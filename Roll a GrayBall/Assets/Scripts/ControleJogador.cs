using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleJogador : MonoBehaviour {

	private Rigidbody Jogador;
	public float Velocidade;
	private int Pontuacao;
	public Text TextoPontuacao;
	public Text TextoVitoria;

	void Start () {
		Jogador = GetComponent<Rigidbody> ();
		Pontuacao = 0;
		ContarPontos ();
		TextoVitoria.text = "";
	}
 	
	void FixedUpdate () {//MOVIMENTACAO DA GRAYBALL
		float Horizontal = Input.GetAxis ("Horizontal");
		float Vertical = Input.GetAxis ("Vertical");

		Vector3 movimento = new Vector3 (Horizontal, 0.0f, Vertical);

		Jogador.AddForce (movimento * Velocidade);
	}

	void OnTriggerEnter (Collider ObjInteresse){//SISTEMA DE COLETAR OS COLETAVEIS
		if (ObjInteresse.gameObject.CompareTag ("Coletavel")) {
			ObjInteresse.gameObject.SetActive (false);
			Pontuacao += 1;
			ContarPontos ();
		}
	}

	void ContarPontos(){
		TextoPontuacao.text = "Pontuação: " + Pontuacao.ToString ();
		if (Pontuacao >= 13) {
			TextoVitoria.text = "Fase Concluída!";
			gameObject.SetActive (false);
		}
	}
}
