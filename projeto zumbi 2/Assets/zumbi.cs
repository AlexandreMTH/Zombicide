using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zumbi : MonoBehaviour {

	NavMeshAgent zombieAgent;

	public GameObject playerObj;
	player playerCode;

	float vida;

	public int pontosDeAcao = 2;

	int ptsAcao;

	Animator an;

	bool hasSetup;

	[Tooltip ("vida do zumbi dependendo do level do player")]
	public float vidaPlayer1, vidaPlayer2, vidaPlayer3;

	public bool onZombieTurn;

	void Start() {
		zombieAgent = GetComponent<NavMeshAgent> ();
		onZombieTurn = false;
		playerCode = playerObj.GetComponent<player> ();
		an = GetComponentInChildren<Animator> ();
		ptsAcao = pontosDeAcao;
	}

	void Update(){

		print (ptsAcao);
		
		if (ptsAcao <= 0) {
			onZombieTurn = false;
			player.turno = "Player";
			ptsAcao = pontosDeAcao;
		} else if (player.turno == "Zumbis") {
			onZombieTurn = true;
		}

		if (player.level == 1) {
			vida = vidaPlayer1;
		}	else if (player.level == 2) {
			vida = vidaPlayer2;
		}	else if (player.level >= 3) {
			vida = vidaPlayer3;
		}

		Vector3 playerPos = playerObj.transform.position;

		if (onZombieTurn) {
			an.SetBool ("Walking", true);
			zombieAgent.SetDestination (playerPos);
		} else {
			an.SetBool ("Walking", false);
			zombieAgent.SetDestination (transform.position);
		}


	}

	void InitialSetup () {
		if (!hasSetup) {
			ptsAcao = pontosDeAcao;
			hasSetup = true;
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

	void OnTriggerExit (Collider coll ){

		if (coll.gameObject.tag == "gastaPA") {
			ptsAcao--;

		}

	}		
}
