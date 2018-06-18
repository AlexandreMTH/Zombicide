using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public static int objetivoColetado = 0; 

	// Use this for initialization
	public Text objetivos, pontosDeAcao, vidas;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		objetivos.text = "OBJETIVOS COLETADOS: " + objetivoColetado + "/4";
		pontosDeAcao.text = "PONTOS DE AÇÃO: " + player.PontosDeAcao + "/3";
		vidas.text = "VIDAS: " + player.vidas + "/2";
	}
}
