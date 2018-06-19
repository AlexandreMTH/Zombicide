using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaZumbi : MonoBehaviour {

	public static bool temZumbi = false;

	void OnTriggerEnter(Collider col){
		if (col.tag == "zumbi")	temZumbi = true;		
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "zumbi")	temZumbi = true;			
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "zumbi")
			temZumbi = false;			
		
	}
}
