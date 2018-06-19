using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoAzul : MonoBehaviour {

	public static bool ativaSpawnAzul = false; 

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player"){
			
			player.Exp += 5;
			ativaSpawnAzul = true; 
			Destroy(this.gameObject, 0.1f);
		}

	}
}
