using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sirenes : MonoBehaviour {

	public GameObject LuzVer, LuzAzul;
	bool controleLuzVer, controleLuzAzul;
	float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		LuzVer.SetActive (controleLuzVer);
		LuzAzul.SetActive (controleLuzAzul);

		timer += Time.deltaTime;

		if (timer > 0.3f && controleLuzAzul == true) {

			timer = 0;
			controleLuzAzul = false;
			controleLuzVer = true;


		}

		if (timer > 0.3f && controleLuzVer == true) {

			timer = 0;
			controleLuzVer = false;
			controleLuzAzul = true;


		}


	}
}
