using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour {

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player"){
			player.Exp += 5;
			print(player.Exp);
			Destroy(this.gameObject, 0.1f);
		}

	}
}
