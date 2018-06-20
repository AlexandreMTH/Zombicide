using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour {

	bool criazumbi;
	float random;
	public GameObject zumbiNormal;
	public GameObject zumbiDiferente;
	Vector3 posicao;

	void Start () {

		posicao = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (player.turno == "Player") {

			criazumbi = true;

		}

		if (player.turno == "Zumbis" && criazumbi == true) {

			random = Random.Range (1, 5);
//
//				if (random > 3)	{
//
//				Instantiate(zumbiDiferente, transform.position, transform.rotation);
//
//			}
			//if (random < 3)	{

				Instantiate(zumbiNormal, transform.position, transform.rotation);

			//}

			criazumbi = false;

		}
		
	}
}
