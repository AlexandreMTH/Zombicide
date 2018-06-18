using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject fases, creditos;
	static bool faseAtiva, creditosAtiva; 

	// Use this for initialization

	public void Jogar(){
		if (!faseAtiva) fases.SetActive(!faseAtiva);
		faseAtiva = !faseAtiva;	
	}

	public void Creditos(){
		if (!creditosAtiva) creditos.SetActive(!creditosAtiva);	
		else creditos.SetActive(!creditosAtiva);
		creditosAtiva = !creditosAtiva;
	}

	public void Sair(){
		Application.Quit();
	}

	public void Fase1(){
		SceneManager.LoadScene("Fase A7");
	}

	public void Fase2(){
		SceneManager.LoadScene("Fase C12");
	}
}
