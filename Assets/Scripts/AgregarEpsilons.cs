using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AgregarEpsilons : MonoBehaviour {
	Text txtFortaleza;
	Text txtHabilidadMotora;
	
	// Use this for initialization
	void Start () {
		txtFortaleza = GameObject.Find ("txtFortaleza").GetComponent<UnityEngine.UI.Text>();
		txtHabilidadMotora = GameObject.Find ("txtHabilidadMotora").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if ((txtFortaleza.text == "3") && (txtHabilidadMotora.text == "3")) {
			ApplicationModel.epsilons += 1;
			ApplicationModel.puntaje += ApplicationModel.constAgregar;
		
			ApplicationModel.ActualizarContadores ();
		}
	}
}
