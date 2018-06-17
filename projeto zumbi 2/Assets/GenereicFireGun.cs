using UnityEngine;

public class GenereicFireGun : MonoBehaviour {
	
	public float danoArma;
	public float alcance;
	public GameObject SpawnTiro;

	void Update () {




		if (player.combateON && player.PontosDeAcao >0) {
			if (Input.GetMouseButtonDown (0) ) {

				tiro ();


			}
}
}

	void tiro (){

		RaycastHit hit;

		if (Physics.Raycast (SpawnTiro.transform.position, SpawnTiro.transform.forward, out hit, alcance)) {

			zumbi danozumbi = hit.transform.GetComponent<zumbi>();

			if (danozumbi != null) {

				danozumbi.SofreDano (danoArma);

			}



			Debug.Log (hit.transform.name);



		}


	}

	void OnDrawGizmos(){

		//so pra debug
		Gizmos.color = Color.blue;
		Vector3 direction = SpawnTiro.transform.forward * alcance;
		Gizmos.DrawRay (transform.position, direction);

	}
}
