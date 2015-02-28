using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ApplicationModel {
	
	public static int puntaje;
	public static float speedFlask;
	public static int alfas;
	public static int betas;
	public static int constAgregar;
	public static int constPerdido;

	static Text txtPuntaje;
	static Text txtAlfas;
	static Text txtBetas;

	public static void ActualizarContadores(){
		txtPuntaje = GameObject.FindGameObjectWithTag("txtpuntaje").GetComponent<UnityEngine.UI.Text>();
		txtAlfas = GameObject.Find ("txtAlfas").GetComponent<UnityEngine.UI.Text>();
		txtBetas = GameObject.Find ("txtBetas").GetComponent<UnityEngine.UI.Text>();
		txtPuntaje.text = string.Format ("Puntaje:{0}", ApplicationModel.puntaje);
		txtAlfas.text = string.Format ("Alfas:{0}", ApplicationModel.alfas);
		txtBetas.text = string.Format ("Betas:{0}", ApplicationModel.betas);
	}
}
