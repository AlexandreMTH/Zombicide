using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicks : MonoBehaviour {
	static public float t0, tempoClick;
	static public bool longLeftClick, shortLeftClick, LeftMouseClickCounter, LeftClicked, LeftDoubleClick;
	static public int ShortLeftClicksCounter;


	
	public static void detectaclick(){



		if (Input.GetMouseButtonDown (0)) {

			LeftMouseClickCounter = true;

		}


		if (LeftMouseClickCounter == true) {

			tempoClick += Time.deltaTime;

		}

		if (tempoClick >= 0.5f) {

			tempoClick = 0f;
			LeftMouseClickCounter = false;
			LeftDoubleClick = false;
			ShortLeftClicksCounter = 0;

			if (ShortLeftClicksCounter > 2) {
				ShortLeftClicksCounter = 2;
			}

		}
		//detecta intervalo entre um click e outro (usar para clickduplo)



		if (Input.GetMouseButtonUp (0)) 
		{
			t0 = 0;  

			t0 += Time.deltaTime;

			longLeftClick = false; 

			shortLeftClick = false;
		}
		// clique curto


		if (Input.GetMouseButton(0))
		{
			t0 += Time.deltaTime;
			if (t0 < 0.2){

				longLeftClick = false;
				shortLeftClick = true;
			} 


			if (t0 > 0.2){ 
				longLeftClick = true; 
				shortLeftClick = false;
			} 

			//clique longo
		}

		if (Input.GetMouseButtonDown (0) && tempoClick < 0.5) {
			ShortLeftClicksCounter ++;
			//clicou = false;


		}

		if (ShortLeftClicksCounter == 2 && LeftMouseClickCounter == true) {

			LeftDoubleClick = true;

		}

	}
}
