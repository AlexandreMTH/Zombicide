using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sirenes : MonoBehaviour {

	public GameObject LuzVer, LuzAzul;
	bool controleLuzVer = true, controleLuzAzul, sirene = true;
	float timer;
	public GameObject spawn;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		spawn.SetActive (sirene);
		LuzVer.SetActive (controleLuzVer);
		LuzAzul.SetActive (controleLuzAzul);
		if (sirene) {
			timer += Time.deltaTime;

			if (timer > 0.6f && controleLuzAzul == true) {

				timer = 0;
				controleLuzAzul = false;
				controleLuzVer = true;


			}

			if (timer > 0.6f && controleLuzVer == true) {

				timer = 0;
				controleLuzVer = false;
				controleLuzAzul = true;


			}


		}

		if (sirene == false) {
			controleLuzVer = false;
			controleLuzAzul = false;



		}


	}

	void OnTriggerStay (Collider coll){

		if (coll.gameObject.tag == "Player") {

			if (Input.GetKeyDown (KeyCode.E) && player.PontosDeAcao > 0) {

				sirene = false;
				player.PontosDeAcao--;

			}

		}

	}
}
