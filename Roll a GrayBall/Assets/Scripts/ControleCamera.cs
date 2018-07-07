using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamera : MonoBehaviour {

	public GameObject Jogador;
	private Vector3 offset;

	void Start () {
		offset = transform.position - Jogador.transform.position;
	}

	void LateUpdate () {
		transform.position = Jogador.transform.position + offset;
	}
}
