using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AgregarAlfa : MonoBehaviour {
	//Text txtInteligencia;
	//Text txtAtencion;

	// Use this for initialization
	void Start () {
		//txtInteligencia = GameObject.Find ("txtInteligencia").GetComponent<UnityEngine.UI.Text>();
		//txtAtencion = GameObject.Find ("txtAtencion").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent<Atributos>().casta == (int)ApplicationModel.Casta.alfa) {
			ApplicationModel.alfas += 1;
			ApplicationModel.puntaje += ApplicationModel.constAgregar;
			//AudioSource.PlayClipAtPoint(keyGrab, transform.position)

			ApplicationModel.ActualizarContadores ();
		}
	}
}
