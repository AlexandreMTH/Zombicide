using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericMeleeWeapon : MonoBehaviour {

	float timer;
	//public float tempomax;
	public GameObject areadano;
	public bool quebraporta;
	public static bool dandodano;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print ("dano melee" + dandodano);

		if (player.combateON) {


			//if (player.meleeSelecionado) {

				if (player.PontosDeAcao > 0) {
					if (Input.GetMouseButtonDown (0)) {
						player.PontosDeAcao -= 1;
						areadano.SetActive (true);
						dandodano = true;
					}
			//	}


		
			}
		}

		if (dandodano) {
			timer += Time.deltaTime;



		}

		if (timer >= 0.1f && dandodano == true) {

			dandodano = false;
			areadano.SetActive (false);
			timer = 0;

		}
}


}
