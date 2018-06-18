using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class player : MonoBehaviour {

	static public string turno;

	bool movendo = false;
	bool canMove;
	bool hasSetup;
	Vector3 mouse_pos,object_pos;
	bool explorando;
	public bool cameraSeguePlayer;
	public static bool combateON;
	public Camera cam;
	public GameObject posCam;
	public NavMeshAgent jogador;
	Vector3 posicaoAtual, curPos, lastPos;
	float angle;
	//public Transform target;
	public int CamdisMin, CamdisMax;
	float mousewheel;
	float thisX, thisZ;
	public static int PontosDeAcao = 3, level = 1, vidas = 2;
	int pontosAcao = 3;

	Animator an;
	GameObject currentTile;

	[Tooltip ("xp necessário para subir de level")]
	public float Exp1, Exp2, Exp3;

	public static float Exp;

	public Cards[] cartas;
	bool hasSearched;
	public Image cardImageObj;

	public GameObject[] coisasPraAtivarQuandoPegarMelee;
	public GameObject[] coisasPraAtivarQuandoPegarRanged;
	string weaponType;
	bool hasRanged;
	bool hasMelee;

//	float camY;

	void Start(){
		an = GetComponentInChildren<Animator> ();
		jogador = GetComponent <NavMeshAgent> ();
		movendo = false;
		an.SetBool ("Walking", false);
		canMove = true;
		turno = "Player";
		PontosDeAcao = pontosAcao;
	}


	void Update () {

		print (turno);

		if (player.turno != "Player") {
			canMove = false;
			hasSetup = false;
		} else {
			InitialSetup ();
		}
			
		if (player.PontosDeAcao <= 0) {
			player.turno = "Zumbis";
		}

		utilidades ();
		clicks.detectaclick ();

		if (canMove) {
			movimentacao ();
			combate ();
		}

		cameracontrol ();
		LevelUp ();
		Procura ();

//		Debug.Log (movendo);		

	}


	void InitialSetup () {
		if (!hasSetup) {
			PontosDeAcao = pontosAcao;
			canMove = true;
			hasSearched = false;
			hasSetup = true;
		}
	}

		
	void Procura() {

		if (Input.GetKeyDown(KeyCode.F) && PontosDeAcao >= 1 && !hasSearched && player.turno == "Player") {
			if (currentTile.name == "Interior") {
				hasSearched = true;

				int i = Random.Range (0, 5);

				cardImageObj.sprite = cartas [i].sprite;
				cardImageObj.transform.parent.gameObject.SetActive (true);
				canMove = false;

				StartCoroutine (SearchExitWait ());

				if (cartas[i].type == "Melee") {
					weaponType = "Melee";
					hasMelee = true;
					for (int b = 0; b < coisasPraAtivarQuandoPegarMelee.Length; b++) {
						coisasPraAtivarQuandoPegarMelee [b].SetActive (true);
						coisasPraAtivarQuandoPegarRanged [2].SetActive (false);
					}
				} else if (cartas[i].type == "Ranged") {
					weaponType = "Ranged";
					hasRanged = true;
					for (int b = 0; b < coisasPraAtivarQuandoPegarRanged.Length; b++) {
						coisasPraAtivarQuandoPegarRanged [b].SetActive (true);
						coisasPraAtivarQuandoPegarMelee [2].SetActive (false);
					}
				}

				PontosDeAcao--;

			} else {
				print ("VC N PODE PDROCURAR ITEM PORRRA");
			}
		}

	}


	void LevelUp(){

		if (level == 1 && Exp >= Exp1) {

			//Exp = 0;
			level++;

		}

		if (level == 2 && Exp >= Exp2) {
			//Exp = 0;
			level++;

		}

		if (level == 3 && Exp >= Exp3) {

			level++;

		}

	}


	void movimentacao (){if(Time.timeScale != 0){



		posicaoAtual = this.transform.position;




			if (clicks.shortLeftClick) {

				Ray ray = cam.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;



				if (Physics.Raycast (ray, out hit)) {

					jogador.SetDestination (hit.point);
	}

	 }
			// o jogaodor se dirige para onde o mouse clicou

			if (clicks.LeftDoubleClick) {

				jogador.speed = 15;
				jogador.acceleration = 16;
			}

			if (movendo == false) {

				jogador.speed = 10;
				jogador.acceleration = 8;

			}
	  }
	   }


	void combate(){

		if (Input.GetKeyDown(KeyCode.Alpha1) && hasMelee) {
			SelecionaMelee ();
		} else if (Input.GetKeyDown(KeyCode.Alpha2) && hasRanged) {
			SelecionaRanged ();
		}

		//float cooldown = 0;

		if (Input.GetMouseButtonDown(1)){

			combateON = true;

		}
		//liga a boolean de combate

		else if (Input.GetMouseButtonUp(1)){

			combateON = false;

		}
		//desliga a boolean de combate



		if (combateON) {
			
			posicaoAtual = this.transform.position;
					mouse_pos = Input.mousePosition;
					//mouse_pos.z = 5.23; //The distance between the camera and object
					object_pos = Camera.main.WorldToScreenPoint (transform.position);
					mouse_pos.x = mouse_pos.x - object_pos.x;
			        mouse_pos.x *= -1;
					mouse_pos.y = mouse_pos.y - object_pos.y;
					angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (new Vector3 (0, angle, 0) + new Vector3 (0, -90, 0));
			//faz com que o player mire onde o mouse estiver


			jogador.SetDestination (posicaoAtual);
			// se o jogador estiver em modo de combate ele n sai da posicao
		}




	}
		


	void cameracontrol(){if(Time.timeScale != 0){

			if (Input.GetAxis ("Horizontal")  != 0 || Input.GetAxis ("Vertical") != 0) {

				cameraSeguePlayer = false;

			}

			if (Input.GetKeyDown (KeyCode.Space)) {


				cameraSeguePlayer = true; 

			}


			thisX = this.transform.position.x;
			thisZ = this.transform.position.z;
		
			cam.transform.position = posCam.transform.position;
		//transforma a posicão da camera na posicao do objeto

			mousewheel = Input.mouseScrollDelta.y;
			//Debug.Log(mousewheel);

			if (cameraSeguePlayer) {

				posCam.transform.position = new Vector3 (thisX, posCam.transform.position.y, thisZ);

			} else {

				posCam.transform.position = new Vector3 (posCam.transform.position.x + Input.GetAxis ("Horizontal"), posCam.transform.position.y , posCam.transform.position.z + Input.GetAxis ("Vertical"));

			}

			if (mousewheel > 0) {
				//	print ("roloupracima"); 
				posCam.transform.position -= new Vector3 (0, 1, 0); 

				//camY -= 1;
				mousewheel = 0;
			}
		//se mouse pra cima aproxima a camera

			if (mousewheel < 0) {
				//	print ("roloupracima"); 
				posCam.transform.position += new Vector3 (0, 1, 0); 
				//camY += 1;
				mousewheel = 0;
			}

			if (mousewheel == 0) {

				//camY += 0;

			}
		// caso mouse pra baixo afasta a camera

			if (posCam.transform.position.y < CamdisMin +1) {

				posCam.transform.position += new Vector3 (0, 1, 0) ;
				//camY += 1;
			}

		//limite minimo da camera


			if (posCam.transform.position.y > CamdisMax - 1) {

				posCam.transform.position -= new Vector3 (0, 1, 0);
				//camY -= 1;

			}

		// limite max da camera

		}
	}


	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "gastaPA") {

			currentTile = coll.gameObject;

		}
	}

	void OnTriggerExit (Collider coll ){

		if (coll.gameObject.tag == "gastaPA") {

			PontosDeAcao--;

		}

	}


	void utilidades(){

		//jogador.angularSpeed = 360f / Time.deltaTime;

		curPos = this.transform.position;
		if (curPos == lastPos) {

			movendo = false;
			an.SetBool ("Walking", false);

		} else {

			movendo = true;
			an.SetBool ("Walking", true);
		}

		lastPos = curPos;
		// detecta se o objeto está parado

	}


	IEnumerator SearchExitWait () {
		yield return new WaitForSeconds (2f);

		cardImageObj.transform.parent.gameObject.SetActive (false);
		canMove = true;
	}

	public void SelecionaRanged() {
		coisasPraAtivarQuandoPegarRanged [2].SetActive (true);
		coisasPraAtivarQuandoPegarMelee [2].SetActive (false);
	}

	public void SelecionaMelee() {
		coisasPraAtivarQuandoPegarRanged [2].SetActive (false);
		coisasPraAtivarQuandoPegarMelee [2].SetActive (true);
	}
}

