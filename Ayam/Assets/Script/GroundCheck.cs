using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	public bool gc;

	void OnTriggerEnter(Collider col){
		gc = true;
	}

	void OnTriggerStay(Collider col){
		gc = true;
	}

	void OnTriggerExit(Collider col){
		gc = false;
	}
}
