using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericMeleeWeapon : MonoBehaviour {

	float timer, timer2 = 0f;
	//public float tempomax;
	public GameObject areadano;
	public bool quebraporta;

	bool rodatimer;
	public static bool dandodano;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		print ("dano melee" + dandodano);

		areadano.SetActive (dandodano);

		if (rodatimer) {
			timer2 += Time.deltaTime;

		}

		if (timer2 >= 0.8f) {
			rodatimer = false;
			timer2 = 0f;

		}

		if (player.combateON) {


//			if (player.meleeSelecionado) {
//
//				if (player.PA_Arma_melee > 0) {
//
//					if (Input.GetMouseButtonDown (0)) {
//
//					if (timer2 == 0) {
//						player.PA_Arma_melee -= 1;
//						rodatimer = true;
//						//areadano.SetActive (true);
//						dandodano = true;
//					}
//
//				//	}
//				}





		//	}

			if (player.PA_Arma_melee <= 0 && player.PontosDeAcao > 0) {
				if (Input.GetMouseButtonDown (0)) {
					player.PontosDeAcao -= 1;
					rodatimer = true;
					//areadano.SetActive (true);
					dandodano = true;
				}
			}
		}

		if (dandodano) {
			timer += Time.deltaTime;



		}

		if (timer >= 0.1f && dandodano == true) {

			dandodano = false;

			timer = 0;

		}
	}


}
//}