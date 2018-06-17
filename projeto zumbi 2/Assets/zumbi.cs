using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zumbi : MonoBehaviour {

	public float vida;




	public void SofreDano( float danosofrido){

		vida -= danosofrido;

		if (vida <= 0) {

			morreu ();

		}



	}


	void morreu(){

		Debug.Log ("zumbi morreu");


	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
