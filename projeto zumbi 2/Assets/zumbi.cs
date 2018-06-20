using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zumbi : MonoBehaviour {

	NavMeshAgent zombieAgent;

	GameObject currentTile, currentTile2;

	GameObject playerObj;
	player playerCode;

	float vida;

	public int pontosDeAcao = 1;

	int ptsAcao;

	Animator an;
	float timer;
	bool hasSetup;

	[Tooltip ("vida do zumbi dependendo do level do player")]
	public float vidaPlayer1, vidaPlayer2, vidaPlayer3;

	public bool onZombieTurn;

	void Start() {
		zombieAgent = GetComponent<NavMeshAgent> ();
		onZombieTurn = false;
		playerObj = GameObject.FindWithTag ("Player");
		playerCode = playerObj.GetComponent<player> ();
		an = GetComponentInChildren<Animator> ();
		ptsAcao = pontosDeAcao;

	}

	void Update(){
		
//		if (currentTile != currentTile2) {
//			ptsAcao--;
//			Debug.Log ("zirigdushi");
//		}

		if (player.turno == "Player") {
			onZombieTurn = false;
			zombieAgent.SetDestination (this.transform.position);
			timer = 0;
			player.turno = "Player";
			ptsAcao = pontosDeAcao;
		}

		print (ptsAcao);
		
		if (ptsAcao <= 0) {
			onZombieTurn = false;
			player.turno = "Player";
			ptsAcao = pontosDeAcao;
		} else if (player.turno == "Zumbis") {
			onZombieTurn = true;
			timer += Time.deltaTime;
		}

//		if (player.level == 1) {
//			vida = vidaPlayer1;
//		}	else if (player.level == 2) {
//			vida = vidaPlayer2;
//		}	else if (player.level >= 3) {
//			vida = vidaPlayer3;
//		}

		Vector3 playerPos = playerObj.transform.position;

		if (onZombieTurn) {
			
			if (currentTile == playerCode.currentTile) {


				an.Play ("Attack");

				player.vidas--;
				ptsAcao--;

			} if (onZombieTurn) {
				
				an.SetBool ("Walking", true);
				zombieAgent.SetDestination (playerPos);
				zombieAgent.isStopped = false;

			}

		}  if(timer > 3f ) {
			an.SetBool ("Walking", false);
			//zombieAgent.SetDestination (this.transform.position);
			zombieAgent.isStopped = true;
			timer = 0;
			ptsAcao--;
		}


	}

	void InitialSetup () {
		if (!hasSetup) {
			ptsAcao = pontosDeAcao;
			hasSetup = true;
			zombieAgent.isStopped = true;
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

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "gastaPA") {

			currentTile = coll.gameObject;

		}
	}

	void OnTriggerExit (Collider coll ){
		//Debug.Log ("tchau");

		if (coll.gameObject.tag == "gastaPA") {
			currentTile2 = coll.gameObject;

		}

	}	

	IEnumerator Wait () {
		yield return new WaitForSeconds (1f);

		
	}

}
