using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carro : MonoBehaviour {

	Vector3 mouse_pos;
	public Transform target; 
	Vector3 object_pos;
	public float velocidade = 0;
	float angle;
	Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {



//		Debug.Log (rb.velocity);

		olhamouse ();
		acelerar ();


	}


	void acelerar(){

//		if (Input.GetMouseButton (0)) {
//
//			rb.constraints = RigidbodyConstraints.None;
//
//			rb.AddForce  (new Vector3 (mouse_pos.x, 0, mouse_pos.y)* Time.deltaTime * velocidade);
//
//
//		}
//	
//
//
//		if (Input.GetMouseButton(1)){
//
//			rb.constraints = RigidbodyConstraints.None;
//
//			rb.velocity = new Vector3 (mouse_pos.x, -5, mouse_pos.y) * Time.deltaTime * velocidade /3 * -1;
//
//
//		}

//		if (rb.velocity == Vector3.zero) {
//
//			rb.constraints = RigidbodyConstraints.FreezeAll;
//
//		}
	}




	void olhamouse(){

		//if (Input.GetMouseButton (1)) {
//			mouse_pos = Input.mousePosition;
//			//mouse_pos.z = 5.23; //The distance between the camera and object
//			object_pos = Camera.main.WorldToScreenPoint (target.position);
//			mouse_pos.x = mouse_pos.x - object_pos.x;
//			mouse_pos.y = mouse_pos.y - object_pos.y;
//			angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
//			transform.rotation = Quaternion.Euler (new Vector3 (0, angle, 0) * -1);

		//}
	}
}
