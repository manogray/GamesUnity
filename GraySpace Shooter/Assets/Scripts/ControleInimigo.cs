using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigo : MonoBehaviour {

	private Rigidbody CorpoInimigo;
	private AudioSource SomTiro;
	public float Velocidade;
	public GameObject Tiro;
	public Transform SpawnerTiro;
	public GameObject ExplosaoInimigo;
	public float frequenciaTiro;
	public GameObject Mira;
	private Mira miraScript;
	private float AlturaMinima, AlturaMaxima;

	private float proximoTiro;

	void Start (){
		CorpoInimigo = GetComponent<Rigidbody> ();
		SomTiro = GetComponent<AudioSource> ();
		miraScript = Mira.GetComponent<Mira> ();
		CorpoInimigo.velocity = transform.forward * Velocidade;
		AlturaMinima = -10.44f;
		AlturaMaxima = 10.44f;
		frequenciaTiro = (Random.Range (60,100))/100.0f;
	}

	void Update (){
		if (Time.time > proximoTiro) {
			proximoTiro = Time.time + frequenciaTiro;
			Instantiate (Tiro, SpawnerTiro.position, Tiro.transform.rotation);
			SomTiro.Play ();
		}
	}

	void OnTriggerEnter (Collider algo){
		if (algo.tag == "Tiro") {
			Instantiate (ExplosaoInimigo, transform.position, transform.rotation);
			Destroy (algo.gameObject);
			Destroy (gameObject);
		}
	}

	void FixedUpdate (){
		CorpoInimigo.position = new Vector3 (0.0f,Mathf.Clamp(CorpoInimigo.position.y,AlturaMinima,AlturaMaxima),CorpoInimigo.position.z);
	}

}
