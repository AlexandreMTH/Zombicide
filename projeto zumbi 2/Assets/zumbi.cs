using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zumbi : MonoBehaviour {

	float vida;

	[Tooltip ("vida do zumbi dependendo do level do player")]
	public float vidaPlayer1, vidaPlayer2, vidaPlayer3;

	void Update(){

		if (player.level == 1) {
			vida = vidaPlayer1;

		}

		if (player.level == 2) {

			vida = vidaPlayer2;

		}

		if (player.level >= 3) {

			vida = vidaPlayer3;

		}


	}

	public void SofreDano( float danosofrido){

		vida -= danosofrido;

		if (vida <= 0) {

			morreu ();

		} else {

			danosofrido = 0;

		}



	}


	void morreu(){

		Debug.Log ("zumbi morreu");
		player.Exp++;


	}
		
}
