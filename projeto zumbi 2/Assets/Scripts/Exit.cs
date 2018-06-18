using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player"){

			//if (HUD.objetivoColetado >= 4)
			player.Exp += 5;
			HUD.objetivoColetado +=1;
			print(player.Exp);
			Destroy(this.gameObject, 0.1f);
		}

	}

}
