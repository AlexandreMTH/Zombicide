using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player : MonoBehaviour {

	bool movendo;
	Vector3 mouse_pos,object_pos;
	bool explorando;
	public bool combateON, cameraSeguePlayer;
	public Camera cam;
	public GameObject posCam;
	public NavMeshAgent jogador;
	Vector3 posicaoAtual, curPos, lastPos;
	float angle;
	public Transform target;
	public int CamdisMin, CamdisMax;
	float mousewheel;
	float thisX, thisZ;
//	float camY;

	void Start(){

		jogador = GetComponent <NavMeshAgent> ();

	}


	void Update () {

		utilidades ();
		clicks.detectaclick ();
		movimentacao ();
		combate ();
		cameracontrol ();


//		Debug.Log (movendo);		

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

		float cooldown = 0;

		if (Input.GetMouseButtonDown(1)){

			combateON = true;

		}
		//liga a boolean de combate

		if (Input.GetMouseButtonUp(1)){

			combateON = false;

		}
		//desliga a boolean de combate



		if (combateON) {
			

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

		if (combateON) {
			if (Input.GetMouseButton (0) && cooldown <= 0f) {

				Debug.Log ("oi");
				cooldown = 0.8f;

			}

			if (cooldown < 0) {

				cooldown = 0;
			}


		}




	}


	void cameracontrol(){if(Time.timeScale != 0){

			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {

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
			Debug.Log(mousewheel);

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


		if (coll.gameObject.tag == "explorável") {

			//coll = posCam.gameObject.transform.GetChild;
			explorando = true;

		}
	}

	void OnTriggerExit (Collider coll ){

		if (coll.gameObject.tag == "explorável") {

			//Debug.Log ("flws");
			explorando = false;

		}

	}


	void utilidades(){

		//jogador.angularSpeed = 360f / Time.deltaTime;

		curPos = this.transform.position;
		if (curPos == lastPos) {

			movendo = false;
		} else {

			movendo = true;
		}
		lastPos = curPos;
		// detecta se o objeto está parado

	}

		}

