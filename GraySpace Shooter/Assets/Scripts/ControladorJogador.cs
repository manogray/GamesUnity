using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TLimites {
	public float zMin;
	public float zMax;
	public float yMin;
	public float yMax;
}

public class ControladorJogador : MonoBehaviour {

	private Rigidbody CorpoJogador;
	private AudioSource SomTiro;
	public float Velocidade;
	public TLimites limite;
	public float Inclinacao;
	public GameObject Tiro;
	public Transform SpawnerTiro;
	public float frequenciaTiro;

	private float proximoTiro;

	void Start (){
		CorpoJogador = GetComponent<Rigidbody> ();
		SomTiro = GetComponent<AudioSource> ();
	}

	void Update (){

		if (Input.GetButton ("Jump") && Time.time > proximoTiro) {
			proximoTiro = Time.time + frequenciaTiro;
			Instantiate (Tiro, SpawnerTiro.position, Tiro.transform.rotation);
			SomTiro.Play ();
		}
	}

	void FixedUpdate (){
		float Horizontal = Input.GetAxis ("Horizontal");
		float Vertical = Input.GetAxis ("Vertical");

		Vector3 movimento = new Vector3 (0.0f, Vertical, Horizontal);

		CorpoJogador.velocity = movimento * Velocidade;

		CorpoJogador.position = new Vector3 (
			0.0f,
			Mathf.Clamp(CorpoJogador.position.y,limite.yMin,limite.yMax),
			Mathf.Clamp(CorpoJogador.position.z,limite.zMin,limite.zMax)); 

		CorpoJogador.rotation = Quaternion.Euler (0.0f, 0.0f, CorpoJogador.velocity.y * Inclinacao);
	}
}
