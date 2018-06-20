using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

	public static int objetivoColetado = 0; 

	// Use this for initialization
	public Text objetivos, pontosDeAcao, vidas, comida, agua, arroz;
	public GameObject tiroExtra, inventario, morte;
	static bool inventarioAtiva;
	public int fase;
	public Slider xpSlider; 
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		objetivos.text = "OBJETIVOS COLETADOS: " + objetivoColetado + "/4";
		pontosDeAcao.text = "PONTOS DE AÇÃO: " + player.PontosDeAcao + "/3";
		vidas.text = "VIDAS: " + player.vidas + "/2";

		if (player.level == 3){

			tiroExtra.SetActive(true);

		}

		if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I)){
			if (!inventarioAtiva) inventario.SetActive(!inventarioAtiva);	
			else inventario.SetActive(!inventarioAtiva);
			inventarioAtiva = !inventarioAtiva;

		}

		BarraDeXP();

		if (fase == 1){



		}

		if (fase == 2){
			if (player.pegouComida){
				comida.text = "Comida: 1/1";
			}
			else {
				comida.text = "Comida: 0/1"; 
			}

			if (player.pegouAgua){
				agua.text = "Água: 1/1";
			}
			else {
				agua.text = "Água: 0/1"; 
			}
			if (player.pegouArroz){
				arroz.text = "Arroz: 1/1";
			}
			else {
				arroz.text = "Arroz: 0/1"; 
			}

		}
		if (player.morreu){

			morte.SetActive(true);
			Time.timeScale = 0;			

		}

	}

	void BarraDeXP(){
		
		xpSlider.value = player.Exp;

	}

	public void Menu(){

		SceneManager.LoadScene("Menu");


	}
}
