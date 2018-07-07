using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDaMorte : MonoBehaviour {

	void OnTriggerExit (Collider qualquerCoisa){
		Destroy (qualquerCoisa.gameObject);
	}
}
