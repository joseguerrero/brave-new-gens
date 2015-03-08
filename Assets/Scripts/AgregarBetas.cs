using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AgregarBetas : MonoBehaviour
{
	Text txtInteligencia;
	Text txtResiliencia;
	
	// Use this for initialization
	void Start () {
		txtInteligencia = GameObject.Find ("txtInteligencia").GetComponent<UnityEngine.UI.Text>();
		txtResiliencia = GameObject.Find ("txtResiliencia").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if ((txtInteligencia.text == "3") && (txtResiliencia.text == "3")) {
			ApplicationModel.betas += 1;
			ApplicationModel.puntaje += ApplicationModel.constAgregar;
		
			ApplicationModel.ActualizarContadores ();
		}
	}
}
