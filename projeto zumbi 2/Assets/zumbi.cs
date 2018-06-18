using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zumbi : MonoBehaviour {

	NavMeshAgent zombieAgent;

	public GameObject playerObj;

	float vida;

	[Tooltip ("vida do zumbi dependendo do level do player")]
	public float vidaPlayer1, vidaPlayer2, vidaPlayer3;

	public bool onZombieTurn;

	void Start() {
		zombieAgent = GetComponent<NavMeshAgent> ();
	}

	void Update(){

		if (player.level == 1) {
			vida = vidaPlayer1;
		}	else if (player.level == 2) {
			vida = vidaPlayer2;
		}	else if (player.level >= 3) {
			vida = vidaPlayer3;
		}

		Vector3 playerPos = playerObj.transform.position;

		if (onZombieTurn) {
			zombieAgent.SetDestination (playerPos);
		}


	}

	public void SofreDano( float danosofrido){

		vida -= danosofrido;

		if (vida <= 0) {

			Morreu ();

		} else {

			danosofrido = 0;

		}



	}


	void Morreu(){

		Debug.Log ("zumbi morreu");
		player.Exp++;


	}
		
}
