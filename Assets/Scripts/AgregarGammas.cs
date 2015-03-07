using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AgregarGammas : MonoBehaviour {
	Text txtAtencion;
	Text txtHabilidadMotora;
	
	// Use this for initialization
	void Start () {
		txtAtencion = GameObject.Find ("txtAtencion").GetComponent<UnityEngine.UI.Text>();
		txtHabilidadMotora = GameObject.Find ("txtHabilidadMotora").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if ((txtAtencion.text == "3") && (txtHabilidadMotora.text == "3")) {
			ApplicationModel.gammas += 1;
			ApplicationModel.puntaje += ApplicationModel.constAgregar;
		
			ApplicationModel.ActualizarContadores ();
		}
	}
}
