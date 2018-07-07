using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDeJogo : MonoBehaviour {
	public GameObject Perigo;
	public GameObject Jogador;
	public GameObject Inimigo;
	public Vector3 SpawnValores;
	public int ContadorPerigo;
	private int Pontos;
	public float IntervaloSpawn;
	public float IniciarIntervalo;
	public float IntervaloOnda;

	public Text ReiniciarTexto;
	public Text pontuacaoTexto;
	public Text gameoverTexto;

	void Start (){
		Pontos = 0;
		gameoverTexto.text = "";
		ReiniciarTexto.text = "";
		ContarPontos ();
		Jogador = GameObject.FindWithTag ("Jogador");
		StartCoroutine (CriarOndas ());
	}

	void Update (){
		if (Jogador == null) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("TelaPrincipal");
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("Menu");
			SceneManager.UnloadSceneAsync ("TelaPrincipal");
		}

	}

	IEnumerator CriarOndas (){

		yield return new WaitForSeconds (IniciarIntervalo);

		while (Jogador != null){
			for (int contador = 0; contador < ContadorPerigo; contador++) {
				Vector3 SpawnPosicao1 = new Vector3 (SpawnValores.x, Random.Range(-SpawnValores.y,SpawnValores.y), SpawnValores.z);
				Quaternion SpawnRotacao1 = Quaternion.identity;
				Instantiate (Perigo, SpawnPosicao1, SpawnRotacao1);
				if(contador%2 == 0){
					Vector3 SpawnPosicao2 = new Vector3 (SpawnValores.x, Random.Range(-SpawnValores.y,SpawnValores.y), SpawnValores.z);
					Quaternion SpawnRotacao2 = Inimigo.transform.rotation;
					Instantiate (Inimigo, SpawnPosicao2, SpawnRotacao2);
				}
				yield return new WaitForSeconds (IntervaloSpawn);
			}
			ContadorPerigo += 1;
			yield return new WaitForSeconds (IntervaloOnda);
		}
	}

	public void AddUmPonto(int NovoPonto){
		Pontos += NovoPonto;
		ContarPontos ();
	}

	public void ExibirGameOver(string texto){
		gameoverTexto.text = texto;
		ReiniciarTexto.text = "Aperte 'R' para reiniciar";
	}

	void ContarPontos (){
		pontuacaoTexto.text = "Pontos: " + Pontos;
	}
}
