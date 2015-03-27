using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ApplicationModel {
	
	public static int puntaje;
	public static float speedFlask;
	public static int alfas;
	public static int betas;
	public static int gammas;
	public static int deltas;
	public static int epsilons;
	public static int reciclados;

	public static int constAgregar;
	public static int constPerdido;
	public static int constReciclar;
	public static int constDetenido;

	static Text txtPuntaje;
	static Text txtAlfas;
	static Text txtBetas;
	static Text txtGammas;
	static Text txtDeltas;
	static Text txtEpsilons;

	//public static float speedInspector1;
	//public static float speedInspector2;

	public static void ActualizarContadores(){
		txtPuntaje = GameObject.FindGameObjectWithTag("txtpuntaje").GetComponent<UnityEngine.UI.Text>();
		txtAlfas = GameObject.Find ("txtAlfas").GetComponent<UnityEngine.UI.Text>();
		txtBetas = GameObject.Find ("txtBetas").GetComponent<UnityEngine.UI.Text>();
		txtGammas = GameObject.Find ("txtGammas").GetComponent<UnityEngine.UI.Text> ();
		txtDeltas = GameObject.Find ("txtDeltas").GetComponent<UnityEngine.UI.Text> ();
		txtEpsilons = GameObject.Find ("txtEpsilons").GetComponent<UnityEngine.UI.Text> ();
		
		txtPuntaje.text = string.Format ("Puntaje: {0}", ApplicationModel.puntaje);
		txtAlfas.text = string.Format ("{0}", ApplicationModel.alfas);
		txtBetas.text = string.Format ("{0}", ApplicationModel.betas);
		txtGammas.text = string.Format ("{0}", ApplicationModel.gammas);
		txtDeltas.text = string.Format ("{0}", ApplicationModel.deltas);
		txtEpsilons.text = string.Format ("{0}", ApplicationModel.epsilons);
	}

	public enum Casta {
		alfa,
		beta,
		gamma,
		delta,
		epsilon
	}
}
