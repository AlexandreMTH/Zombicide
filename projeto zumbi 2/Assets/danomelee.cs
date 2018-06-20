using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danomelee : MonoBehaviour {

	public GameObject seguir;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = seguir.transform.position;
		
	}

	void OnTriggerStay(Collider coll){

		if (coll.gameObject.tag == "porta") {
			

			Destroy (coll.gameObject);
		}


		if (coll.gameObject.tag == "zumbi") {
			print ("oi");
			Destroy (coll.gameObject);

		}
	}
}
