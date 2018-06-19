using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	public int fase;

	public GameObject fimFase;

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player"){
			if (fase == 1){
				if (HUD.objetivoColetado >= 4){ //falta saber se tem zumbi na área
					StartCoroutine(WaitForTheEnd());				
				}
			}

			if (fase == 2){


			}
		}
	}

	IEnumerator WaitForTheEnd(){

		yield return new WaitForSeconds(0.5f);
		fimFase.SetActive(true);	

	}

	public void Menu(){
		SceneManager.LoadScene("Menu");
	}

	public void Fase2(){

		SceneManager.LoadScene("Fase C12");

	}

}
