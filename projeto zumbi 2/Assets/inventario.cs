using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class inventario : MonoBehaviour {

	float timer;
	bool ligadesliga, resetatimer;
	public GameObject inventarioo;

	// Use this for initialization
	void Start () {

		timer = 1.1f;
		//ligadesliga = false;
		
	}
	
	// Update is called once per frame
	void Update () {

//		if (resetatimer == true) {
//
//			timer += Time.deltaTime;
//
//
//		}
//
//		if (ligadesliga == false) {
//
//			resetatimer = false;
//			timer = 0;
//
//		}


		if (Input.GetMouseButtonDown (2)) {

			if (ligadesliga == false) {

				inventarioo.SetActive (true);
				ligadesliga = true;
				Time.timeScale = 0;


			} else {

				inventarioo.SetActive (false);
				ligadesliga = false;
				Time.timeScale = 1;

			}

			//print (ligadesliga);

			}





	}
}
